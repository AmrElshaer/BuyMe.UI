using BuyMe.Application.Common.Interfaces;
using BuyMe.Domain.Common;
using BuyMe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Persistence
{
    public class BuyMeDbContext : DbContext, IBuyMeDbContext
    {
        private readonly ICurrentUserService currentUserService;

        public BuyMeDbContext(DbContextOptions<BuyMeDbContext> options, ICurrentUserService currentUserService)
          : base(options)
        {
            this.currentUserService = currentUserService;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BuyMeDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get ; set ; }
        public DbSet<Product> Products { get ; set ; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get ; set ; }
        public DbSet<Warehouse> Warehouses { get ; set ; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.UtcNow;
                        entry.Entity.CreatedBy = currentUserService.UserId;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = DateTime.UtcNow;
                        entry.Entity.LastModifiedBy = currentUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
