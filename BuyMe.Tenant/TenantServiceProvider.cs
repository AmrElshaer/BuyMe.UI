using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Infrastructure.Identity;
using BuyMe.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading;

namespace BuyMe.Tenant
{
    public class TenantServiceProvider : ITenantServiceProvider
    {

        private readonly IServiceProvider services;

        public TenantServiceProvider(IServiceProvider services)
        {
            this.services = services;
        }
        public string GeneratTenant(string tenant, CancellationToken token = default)
        {
            if (token.IsCancellationRequested)
            {
                throw new TaskCanceledException("Create Tenant");
            }
            string connectionString = $"Server=(localdb)\\mssqllocaldb;Database={tenant};Trusted_Connection=True;MultipleActiveResultSets=true";
            // add BuyMeDbContext
            using var scope = services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<BuyMeDbContext>();
            dbContext.Database.SetConnectionString(connectionString);
            if (dbContext.Database.GetMigrations().Count() > 0)
            {
                dbContext.Database.Migrate();
            }
            // add ApplicationDbContext
            using var scope2 = services.CreateScope();
            var dbContext2 = scope2.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext2.Database.SetConnectionString(connectionString);
            if (dbContext2.Database.GetMigrations().Count() > 0)
            {
                dbContext2.Database.Migrate();
            }
            return connectionString;
        }

    }
}
