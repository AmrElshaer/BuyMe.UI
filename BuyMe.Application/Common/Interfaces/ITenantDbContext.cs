using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface ITenantDbContext
    {
        DbSet<Domain.Entities.Tenant> Tenants { get; set; }
        DbSet<Domain.Entities.OutboxMessage> OutboxMessages { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
