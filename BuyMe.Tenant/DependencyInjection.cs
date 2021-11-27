using BuyMe.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuyMe.Tenant
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTenant(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TenantDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("TenantConnection")));
            services.AddScoped<ITenantDbContext>(provider => provider.GetService<TenantDbContext>());
            services.AddTransient<ITenantServiceProvider, TenantServiceProvider>();
            return services;
        }
    }
}
