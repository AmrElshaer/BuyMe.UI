using BuyMe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Entities = BuyMe.Domain.Entities;

namespace BuyMe.Application.Common.Interfaces
{
    public interface IBuyMeDbContext
    {
        DbSet<Entities.Company> Companies { get; set; }
        DbSet<Entities.Employee> Employees { get; set; }
        DbSet<Entities.Currency> Currencies { get; set; }
        DbSet<Entities.Branch> Branches { get; set; }
        DbSet<Entities.Category> Categories { get; set; }
        DbSet<Entities.Product> Products { get; set; }
        DbSet<Entities.UnitOfMeasure> UnitOfMeasures { get; set; }
        DbSet<Entities.Warehouse> Warehouses { get; set; }
        DbSet<Entities.CustomerType> CustomerTypes { get; set; }
        DbSet<Entities.Customer> Customers { get; set; }
        DbSet<Entities.SalesType> SalesTypes { get; set; }
        DbSet<Entities.SalesOrder> SalesOrders { get; set; }
        DbSet<Entities.SalesOrderLine> SalesOrderLines { get; set; }
        DbSet<Entities.NumberSequence> NumberSequences { get; set; }
        DbSet<Entities.ProductImages> ProductImages { get; set; }
        DbSet<Entities.Template> Templates { get; set; }
        DbSet<TemplateImages> TemplateImages { get; set; }
        DbSet<CategoryDescription> CategoryDescriptions { get; set; }
        DbSet<ProductDescription> ProductDescriptions { get; set; }
        DbSet<Entities.CartItem> CartItems { get; set; }
        DbSet<Entities.MarketingDefaultSetting> MarketingDefaultSettings { get; set; }
        DbSet<Entities.ShipmentType> ShipmentTypes { get; set; }
        DbSet<Entities.Shipment> Shipments { get; set; }
        DbSet<Entities.CustomField> CustomFields { get; set; }
        DbSet<Entities.CustomFieldData> CustomFieldDatas { get; set; }
        DbSet<Entities.InvoiceType> InvoiceTypes { get; set; }
        DbSet<Entities.Invoice> Invoices { get; set; }
        DbSet<Entities.PaymentType> PaymentTypes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}