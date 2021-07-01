using BuyMe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Entities= BuyMe.Domain.Entities;
namespace BuyMe.Application.Common.Interfaces
{
    public interface IBuyMeDbContext
    {
         DbSet<Entities.Company> Companies{ get; set; }
         DbSet<Entities.Employee> Employees{ get; set; }
         DbSet<Entities.Currency> Currencies{ get; set; }
         DbSet<Entities.Branch> Branches{ get; set; }
        DbSet<Entities.Category> Categories { get; set; }
        DbSet<Entities.Product> Products { get; set; }
        DbSet<Entities.UnitOfMeasure> UnitOfMeasures { get; set; }
        DbSet<Entities.Warehouse> Warehouses { get; set; }
        DbSet<Entities.CustomerType> CustomerTypes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
