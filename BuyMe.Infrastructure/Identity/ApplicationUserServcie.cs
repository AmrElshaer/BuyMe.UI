using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Employee.Commonds.CreateEdit;
using BuyMe.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Infrastructure.Identity
{
    public class ApplicationUserServcie : IApplicationUserServcie
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserServcie(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }
        public async Task<string> AddApplicationUser(string firstName, string lastName, string password, string email, int companyId,string photo)
        {
            var user = new ApplicationUser {FirstName=firstName,
                LastName= lastName,
                Photo=photo,UserName = email,
                Email =email,CompanyId=companyId };
            var result = await _userManager.CreateAsync(user, password);
            var appResult = result.ToApplicationResult();
            if (!appResult.Succeeded)
            {
                var validEx = new ValidationException();
                validEx.Failures.Add( string.Empty,appResult.Errors.ToArray());
                throw validEx;
            }
            return user.Id;
        }
        public async Task RemoveApplicationUser(string id)
        {
            var appUser =await _userManager.FindByIdAsync(id);
            var result= await _userManager.DeleteAsync(appUser);
            var appResult = result.ToApplicationResult();
            if (!appResult.Succeeded)
            {
                var validEx = new ValidationException();
                validEx.Failures.Add(string.Empty, appResult.Errors.ToArray());
                throw validEx;
            }
        }
        public async Task<(bool isRegister,string userId)>TryGetUserAsync(string email,string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return ((user != null && (await _userManager.CheckPasswordAsync(user, password))),user?.Id);
        }
        public async Task EditApplicationUser(string userId,string firstName, string lastName, string password, string email, int companyId, string photo)
        {
            var appUser = await _userManager.FindByIdAsync(userId);
            appUser.FirstName = firstName;
            appUser.LastName = lastName;
            appUser.Email = email;
            appUser.UserName = email;
            appUser.Photo = photo;
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            appUser.PasswordHash = ph.HashPassword(appUser,password);
            var result=  await _userManager.UpdateAsync(appUser);
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
