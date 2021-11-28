using BuyMe.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Tenant
{
    public class TenantDbContext:DbContext, ITenantDbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TenantDbContext).Assembly);
            modelBuilder.Entity<Domain.Entities.Tenant>().HasData(
                new Domain.Entities.Tenant(){
                    TenantName="Default",
                    Id=1
                }
            );
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Domain.Entities.Tenant> Tenants { get; set; }
    }
}
