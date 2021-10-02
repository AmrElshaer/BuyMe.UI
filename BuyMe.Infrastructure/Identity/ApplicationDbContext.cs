using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BuyMe.Infrastructure.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly ITenantService tenantService;
        public string TenantId { get; set; }
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,ITenantService tenantService)
           : base(options)
        {
            this.tenantService = tenantService;
            this.TenantId = this.tenantService.GetTenant()?.Name;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var tenantConnectionString = this.tenantService.GetConnectionString();
            if (!string.IsNullOrEmpty(tenantConnectionString))
            {
               
                    optionsBuilder.UseSqlServer(this.tenantService.GetConnectionString());
                
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SuperAdmin",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            }
            );
            foreach (var rol in ApplicationRoles.GetRoles())
            {
                builder.Entity<IdentityRole>().HasData(new IdentityRole
                {
                    Name = rol,
                    NormalizedName = rol,
                    Id = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
           );
            }
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