using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyMe.Application.Common.Models;
namespace BuyMe.Infrastructure.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = ApplicationRoles.SuperAdmin,
                NormalizedName = ApplicationRoles.SuperAdmin,
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });
            var appUser = new ApplicationUser()
            {
                Id = ADMIN_ID,
                Email = "Admin@buyMe.com",
                EmailConfirmed = true,
                FirstName = "Super",
                LastName = "Admin",
                UserName = "Admin@buyMe.com",
                NormalizedEmail = "ADMIN@BUYME.COM",
                NormalizedUserName = "ADMIN@BUYME.COM"
            };
            //set user password
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "P@ssword1");
            builder.Entity<ApplicationUser>().HasData(appUser);
            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
            base.OnModelCreating(builder);
        }
    }
}
