using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
namespace BuyMe.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddAndMigrateTenantDatabases(configuration);
            services.AddScoped<IBuyMeDbContext>(provider => provider.GetService<BuyMeDbContext>());
            return services;
        }
        public static IServiceCollection AddAndMigrateTenantDatabases(this IServiceCollection services, IConfiguration config)
        {
            var options = services.GetOptions<TenantSettings>(nameof(TenantSettings));
            var defaultConnectionString = options.DefaultConnection;

            services.AddDbContext<BuyMeDbContext>(m =>
            m.UseSqlServer(e => e.MigrationsAssembly(typeof(BuyMeDbContext).Assembly.FullName)));

            var tenants = options.Tenants;
            foreach (var tenant in tenants)
            {
                string connectionString= string.IsNullOrEmpty(tenant.ConnectionString)? defaultConnectionString: tenant.ConnectionString;
                using var scope = services.BuildServiceProvider().CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<BuyMeDbContext>();
                dbContext.Database.SetConnectionString(connectionString);
                if (dbContext.Database.GetMigrations().Any())
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