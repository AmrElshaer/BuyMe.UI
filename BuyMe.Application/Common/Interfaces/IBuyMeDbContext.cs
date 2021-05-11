using BuyMe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface IBuyMeDbContext
    {
         DbSet<Domain.Entities.Company> Companies{ get; set; }
         DbSet<Employee> Employees{ get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
