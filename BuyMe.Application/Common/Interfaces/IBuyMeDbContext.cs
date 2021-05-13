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
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
