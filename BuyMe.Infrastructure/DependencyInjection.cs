using BuyMe.Application.Common.Interfaces;
using BuyMe.Infrastructure.Authorization;
using BuyMe.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace BuyMe.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                  options.UseSqlServer(
                      configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders()
        .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory>(); 
            services.AddTransient<IApplicationUserServcie, ApplicationUserServcie>();
            services.AddTransient<IUserManagerService, UserManagerService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IJwtFactoryService, JwtFactoryService>();
            services.Configure<IdentityOptions>(opts => {
                opts.User.RequireUniqueEmail = false;
                opts.Password.RequiredLength = 8;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
            });
            var jwtAppSettingOptions = configuration.GetSection(nameof(JwtIssuerOptions));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],
                     ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAppSettingOptions[nameof(JwtIssuerOptions.SigningKey)]))
                 };
             });
            // Configure JwtIssuerOptions to use when  generate Token
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtAppSettingOptions[nameof(JwtIssuerOptions.SigningKey)])), SecurityAlgorithms.HmacSha256);
            });
            services.AddTransient<IRoleService, RoleService>();
            return services;
        }
        public static void SeedRoles(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var serviceProvider =(IRoleService)scope.ServiceProvider.GetService(typeof(IRoleService));
            serviceProvider.GenerateRolesAsync().GetAwaiter().GetResult();
        }
    }
}
