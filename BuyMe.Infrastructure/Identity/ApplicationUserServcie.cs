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
        public async Task<string> AddApplicationUser(CreatEditEmployeeCommond employee)
        {
            var user = new ApplicationUser {FirstName=employee.FirstName,
                LastName=employee.LastName,Photo=employee.Photo,UserName = employee.Email,
                Email = employee.Email,CompanyId=employee.CompanyId };
            var result = await _userManager.CreateAsync(user, employee.Password);
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
        public async Task EditApplicationUser(CreatEditEmployeeCommond employee)
        {
            var appUser = await _userManager.FindByIdAsync(employee.UserId);
            appUser.FirstName = employee.FirstName;
            appUser.LastName = employee.LastName;
            appUser.Email = employee.Email;
            appUser.UserName = employee.Email;
            appUser.Photo = employee.Photo;
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, employee.Password);
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
