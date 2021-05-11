using BuyMe.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            string ADMIN_ID ="02174cf0–9412–4cfe-afbf-59f706d72cf6";
            var appUser = new ApplicationUser()
            {
                Id = ADMIN_ID,
                Email = "Admin@buyMe.com",
                EmailConfirmed = true,
                FirstName = "Super",
                LastName = "Admin",
                UserName = "Admin@buyMe.com",
                NormalizedEmail="ADMIN@BUYME.COM",
                NormalizedUserName= "ADMIN@BUYME.COM"
            };
            //set user password
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            appUser.PasswordHash = ph.HashPassword(appUser,"P@ssword1");
            builder.HasData(appUser);
        }
    }
}
