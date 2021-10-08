using BuyMe.Application.Common.Interfaces;
using BuyMe.Domain.Common;
using BuyMe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Persistence
{
    public class BuyMeDbContext : DbContext, IBuyMeDbContext
    {
        private readonly ITenantService tenantService;
        private readonly ICurrentUserService currentUserService;
        public string TenantId { get; set; }
        public BuyMeDbContext(DbContextOptions<BuyMeDbContext> options,ITenantService tenantService, ICurrentUserService currentUserService)
          : base(options)
        {
            this.tenantService = tenantService;
            this.currentUserService = currentUserService;
            this.TenantId = this.tenantService.GetTenant()?.Name;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BuyMeDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var tenantConnectionString = this.tenantService.GetConnectionString();
            if (!string.IsNullOrEmpty(tenantConnectionString))
            {

                optionsBuilder.UseSqlServer(this.tenantService.GetConnectionString());

            }
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SalesType> SalesTypes { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderLine> SalesOrderLines { get; set; }
        public DbSet<NumberSequence> NumberSequences { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<TemplateImages> TemplateImages { get; set; }
        public DbSet<CategoryDescription> CategoryDescriptions { get; set; }
        public DbSet<ProductDescription> ProductDescriptions { get; set; }
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