
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using BuyMe.Infrastructure.Authorization;
using BuyMe.Infrastructure.HealthChecks;
using BuyMe.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Text;

namespace BuyMe.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAndMigrateTenantDatabases(configuration);

            services.AddIdentity<ApplicationUser, IdentityRole>().AddRoles<IdentityRole>()
                .AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>()
           .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory>();
            services.AddTransient<IApplicationUserServcie, ApplicationUserServcie>();
            services.AddTransient<IUserManagerService, UserManagerService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IJwtFactoryService, JwtFactoryService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IEmailService, EmailService>();
            services.Configure<IdentityOptions>(opts =>
            {
                opts.User.RequireUniqueEmail = false;
                opts.Password.RequiredLength = 8;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
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

            // healthy check
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("TenantConnection"), name: "Tenant DB Status",
                tags: new[] { "Tenant DB" })
                .AddCheck<SqlServerHealthCheck>(name: "Organizations Status", tags: new[] { "Organization DB" });
            services.AddHealthChecksUI(setp =>
            {
                setp.MaximumHistoryEntriesPerEndpoint(50);
                setp.SetEvaluationTimeInSeconds(2000);
                setp.AddHealthCheckEndpoint("ByMe Health Check", "http://localhost:5000/health");
                setp.SetMinimumSecondsBetweenFailureNotifications(60);
            }).AddInMemoryStorage();
            return services;
        }

        public static IServiceCollection AddAndMigrateTenantDatabases(this IServiceCollection services, IConfiguration config)
        {
            var options = services.GetOptions<TenantSettings>(nameof(TenantSettings));
            var defaultConnectionString = options.DefaultConnection;

            services.AddDbContext<ApplicationDbContext>(m =>
            m.UseSqlServer(e => e.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            var tenants = options.Tenants;
            foreach (var tenant in tenants)
            {
                string connectionString;
                if (string.IsNullOrEmpty(tenant.ConnectionString))
                {
                    connectionString = defaultConnectionString;
                }
                else
                {
                    connectionString = tenant.ConnectionString;
                }
                using var scope = services.BuildServiceProvider().CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.SetConnectionString(connectionString);
                if (dbContext.Database.GetMigrations().Count() > 0)
                {
                    dbContext.Database.Migrate();
                }
            }
            return services;
        }

        public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
        {
            using var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var section = configuration.GetSection(sectionName);
            var options = new T();
            section.Bind(options);
            return options;
        }
    }
}