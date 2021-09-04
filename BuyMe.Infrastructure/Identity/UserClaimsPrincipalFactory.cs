using BuyMe.Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BuyMe.Infrastructure.Identity
{
    public class UserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        private readonly IRoleService roleService;

        public UserClaimsPrincipalFactory(
       UserManager<ApplicationUser> userManager,
       IOptions<IdentityOptions> optionsAccessor, IRoleService roleService)
       : base(userManager, optionsAccessor)
        {
            this.roleService = roleService;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            if (user.CompanyId.HasValue)
            {
                identity.AddClaim(new Claim("CompanyId", user.CompanyId.ToString()));
            }
            (await roleService.GeUserRolesAsync(user.Id)).ToList().ForEach(a => identity.AddClaim(new Claim(ClaimTypes.Role, a)));
            return identity;
        }
    }
}