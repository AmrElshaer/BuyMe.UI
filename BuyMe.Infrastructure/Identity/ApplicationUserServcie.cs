using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Employee.Commonds.CreateEdit;
using BuyMe.Application.Employee.Queries;
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

        public async Task<string> AddApplicationUser(CreatEditEmployeeCommond creatEditEmployee)
        {
            var user = new ApplicationUser
            {
                FirstName = creatEditEmployee.FirstName,
                LastName =  creatEditEmployee.LastName,
                Photo = creatEditEmployee.Photo,
                UserName = creatEditEmployee.Email,
                Email = creatEditEmployee.Email,
                CompanyId = creatEditEmployee.CompanyId
            };
            var result = await _userManager.CreateAsync(user, creatEditEmployee.Password);
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

        public async Task EditApplicationUser(CreatEditEmployeeCommond creatEditEmployee)
        {
            var appUser = await _userManager.FindByIdAsync(creatEditEmployee.UserId);
            appUser.FirstName = creatEditEmployee.FirstName;
            appUser.LastName = creatEditEmployee.LastName;
            appUser.Email = creatEditEmployee.Email;
            appUser.UserName = creatEditEmployee.Email;
            appUser.Photo = creatEditEmployee.Photo;
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, creatEditEmployee.Password);
            var result = await _userManager.UpdateAsync(appUser);
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