using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace BuyMe.Infrastructure.Identity
{
    public class ApplicationUserServcie : IApplicationUserServcie
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ApplicationUserServcie(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            this._userManager = userManager;
            _context = context;
        }

        public async Task<string> AddApplicationUser(User userModel)
        {
            var user = new ApplicationUser();
            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.Photo = userModel.Photo;
            user.UserName = userModel.Email;
            user.Email = userModel.Email;
            user.CompanyId = userModel.CompanyId;
            var result = await _userManager.CreateAsync(user, userModel.Password);
            var appResult = result.ToApplicationResult();
            if (!appResult.Succeeded)
            {
                var validEx = new ValidationException();
                validEx.Failures.Add(string.Empty, appResult.Errors.ToArray());
                throw validEx;
            }
            return user.Id;
        }

        public async Task RemoveApplicationUser(string id)
        {
            var appUser = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(appUser);
            var appResult = result.ToApplicationResult();
            if (!appResult.Succeeded)
            {
                var validEx = new ValidationException();
                validEx.Failures.Add(string.Empty, appResult.Errors.ToArray());
                throw validEx;
            }
        }

        public async Task<bool> EmailExistAsync(string email, int companyId)
        {
            return (await _context.Users.FirstOrDefaultAsync(a => a.Email == email && a.CompanyId == companyId)) != null ? true : false;
        }

        public async Task<(bool isRegister, string userId)> TryGetUserAsync(string email, int companyId, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(a => a.Email == email && a.CompanyId == companyId);
            return ((user != null && (await _userManager.CheckPasswordAsync(user, password))), user?.Id);
        }

        public async Task EditApplicationUser(User userModel)
        {
            var appUser = await _userManager.FindByIdAsync(userModel.UserId);
            appUser.FirstName = userModel.FirstName;
            appUser.LastName = userModel.LastName;
            appUser.Email = userModel.Email;
            appUser.UserName = userModel.Email;
            appUser.Photo = userModel.Photo;
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, userModel.Password);
            var result = await _userManager.UpdateAsync(appUser);
            var appResult = result.ToApplicationResult();
            if (!appResult.Succeeded)
            {
                var validEx = new ValidationException();
                validEx.Failures.Add(string.Empty, appResult.Errors.ToArray());
                throw validEx;
            }
        }
        public async Task ChangePassword(string userId, string oldPass, string newPass)
        {
            var appUser = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.ChangePasswordAsync(appUser, oldPass, newPass);
            var appResult = result.ToApplicationResult();
            if (!appResult.Succeeded)
            {
                var validEx = new ValidationException();
                validEx.Failures.Add(string.Empty, appResult.Errors.ToArray());
                throw validEx;
            }


        }
    }
}