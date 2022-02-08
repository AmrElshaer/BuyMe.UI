using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using BuyMe.Infrastructure.Identity;
using BuyMe.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading;

namespace BuyMe.Tenant
{
    public class TenantServiceProvider : ITenantServiceProvider
    {

        private readonly IServiceProvider services;
        private readonly TenantSettings tenantSettings;

        public TenantServiceProvider(IServiceProvider services, IOptions<TenantSettings> tenantSettings)
        {
            this.services = services;
            this.tenantSettings = tenantSettings.Value;
        }
        public string GeneratTenant(string tenant, CancellationToken token = default)
        {
            if (token.IsCancellationRequested)
            {
                throw new TaskCanceledException("Create Tenant");
            }
            string connectionString = $"Server={this.tenantSettings.ServerName};Database={tenant};Trusted_Connection=True;MultipleActiveResultSets=true";
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
