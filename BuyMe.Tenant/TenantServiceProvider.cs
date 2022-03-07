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
using System.Threading.Tasks;

namespace BuyMe.Tenant
{
    public class TenantServiceProvider : ITenantServiceProvider
    {

        private readonly IServiceProvider services;
        private readonly ITenantDbContext context;
        private readonly TenantSettings tenantSettings;

        public TenantServiceProvider(IServiceProvider services, ITenantDbContext context,IOptions<TenantSettings> tenantSettings)
        {
            this.services = services;
            this.context = context;
            this.tenantSettings = tenantSettings.Value;
        }
        public string GeneratTenant(string tenant, CancellationToken token = default)
        {
            if (token.IsCancellationRequested)
            {
                throw new Application.Common.Exceptions.TaskCanceledException("Create Tenant");
            }
            string connectionString = $"Server={this.tenantSettings.ServerName};Database={tenant};Trusted_Connection=True;MultipleActiveResultSets=true";
            // add BuyMeDbContext
            ApplyPersistanceMigration(connectionString);
            // add ApplicationDbContext
            ApplyInfrastruceMigration(connectionString);
            return connectionString;
        }
        public  void RefreshTenants()
        {
            var tenants = context.Tenants.ToList();
            Parallel.ForEach(tenants, tenant => {
                if (!string.IsNullOrEmpty(tenant.ConnectionString))
                {
                    // add BuyMeDbContext
                    ApplyPersistanceMigration(tenant.ConnectionString);
                    // add ApplicationDbContext
                    ApplyInfrastruceMigration(tenant.ConnectionString);
                }
            });
          

        }

        private void ApplyInfrastruceMigration(string connectionString)
        {
            var scope2 = services.CreateScope();
            var dbContext2 = scope2.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext2.Database.SetConnectionString(connectionString);
            if (dbContext2.Database.GetMigrations().Any()) dbContext2.Database.Migrate();
        }

        private void ApplyPersistanceMigration(string connectionString)
        {
            var scope = services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<BuyMeDbContext>();
            dbContext.Database.SetConnectionString(connectionString);
            if (dbContext.Database.GetMigrations().Any()) dbContext.Database.Migrate();
        }
    }
}
