using BuyMe.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuyMe.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BuyMeDbContext>(options =>
                  options.UseSqlServer(
                      configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IBuyMeDbContext>(provider => provider.GetService<BuyMeDbContext>());
            return services;
        }
    }
}