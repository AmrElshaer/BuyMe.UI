using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Infrastructure.Identity
{
    public class UserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        public UserClaimsPrincipalFactory(
       UserManager<ApplicationUser> userManager,
       IOptions<IdentityOptions> optionsAccessor)
       : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            if (user.CompanyId.HasValue)
            {
               identity.AddClaim(new Claim("CompanyId", user.CompanyId.ToString()));
            }
             
            return identity;
        }
    }
}
