using Microsoft.Extensions.Configuration;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace BuyMe.Tenant
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTenant(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TenantDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("TenantConnection")));
            services.AddAndMigrateTenantDatabases(configuration);
            services.AddScoped<ITenantDbContext>(provider => provider.GetService<TenantDbContext>());
            services.AddTransient<ITenantServiceProvider, TenantServiceProvider>();
            services.RefreshAllTenants();
            return services;
        }
        public static IServiceCollection RefreshAllTenants(this IServiceCollection services)
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var tenantService = scope.ServiceProvider.GetRequiredService<ITenantServiceProvider>();
            tenantService.RefreshTenants();

            return services;

        }
        public static IServiceCollection AddAndMigrateTenantDatabases(this IServiceCollection services,IConfiguration config)
        {
            
            var defaultConnectionString = config.GetConnectionString("TenantConnection");

            services.AddDbContext<TenantDbContext>(m =>
            m.UseSqlServer(e => e.MigrationsAssembly(typeof(TenantDbContext).Assembly.FullName)));
            using var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<TenantDbContext>();
            dbContext.Database.SetConnectionString(defaultConnectionString);
            if (dbContext.Database.GetMigrations().Count() > 0)
            {
                dbContext.Database.Migrate();
            }
            
            return services;
        }
    }
}
