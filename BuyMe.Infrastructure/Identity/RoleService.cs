using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.Infrastructure.Identity
{
    public class RoleService: IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager = null)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task GenerateRolesAsync()
        {
            foreach (var rol in ApplicationRoles.GetRoles())
            {
                if (!await _roleManager.RoleExistsAsync(rol))
                    await _roleManager.CreateAsync(new IdentityRole(rol));
            }
        }
        public async Task UpSertUserRolesAsync(string userId,IEnumerable<string> roles)
        {
            var user=  await _userManager.FindByIdAsync(userId);
            var userRoles = (await GeUserRolesAsync(userId)).ToList();
            // remove unexist roles
            userRoles.ForEach( a=> {
               if (NotExist(roles, a))  _userManager.RemoveFromRoleAsync(user, a).GetAwaiter().GetResult();
            });
            // add roles
            roles.ToList().ForEach(a => {
                if (NotExist(userRoles, a)) _userManager.AddToRoleAsync(user, a).GetAwaiter().GetResult();
            });
           
        }

        bool NotExist<T>(IEnumerable<T> entities,T entity)
        {
            return !(entities.Contains(entity));
        }
        public async Task<IEnumerable<string>> GeUserRolesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.GetRolesAsync(user);
        }
    }
}