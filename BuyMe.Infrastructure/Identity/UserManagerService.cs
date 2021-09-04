using BuyMe.Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyMe.Infrastructure.Identity
{
    public class UserManagerService : IUserManagerService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICurrentUserService currentUserService;

        public UserManagerService(UserManager<ApplicationUser> userManager, ICurrentUserService currentUserService)
        {
            this.userManager = userManager;
            this.currentUserService = currentUserService;
        }

        public async Task<IEnumerable<string>> GetCurrentUserRoles()
        {
            var user = await userManager.FindByIdAsync(currentUserService.UserId);
            return await userManager.GetRolesAsync(user);
        }

        public async Task<(string UserName, string Photo)> GetCurrentUser()
        {
            var appUser = await userManager.FindByIdAsync(currentUserService.UserId);
            return ($"{appUser?.FirstName} {appUser?.LastName}", appUser.Photo);
        }
    }
}