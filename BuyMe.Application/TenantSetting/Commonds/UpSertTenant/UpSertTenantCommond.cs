using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.TenantSetting.Commonds.UpSertTenant
{
    public class UpSertTenantCommond:IRequest<int>
    {
        public int? Id { get; set; }
        public string TenantName { get; set; }
        public string ConnectionString { get; set; }
        public string TenantLogo { get; set; }
        public class UpSertTenantCommondHandler : IRequestHandler<UpSertTenantCommond, int>
        {
            private readonly ITenantDbContext tenantDbContext;
            private readonly ITenantServiceProvider tenantServiceProvider;

            public UpSertTenantCommondHandler(ITenantDbContext tenantDbContext, ITenantServiceProvider tenantServiceProvider)
            {
                this.tenantDbContext = tenantDbContext;
                this.tenantServiceProvider = tenantServiceProvider;
            }
            public async Task<int> Handle(UpSertTenantCommond request, CancellationToken cancellationToken)
            {
                Domain.Entities.Tenant entity;
                if (request.Id.HasValue)
                {
                    var tenant =await tenantDbContext.Tenants.FindAsync(request.Id,cancellationToken);
                    Guard.Against.Null(tenant, request.Id);
                    entity = tenant;
                   
                }
                else
                {
                    entity = new Domain.Entities.Tenant();
                    entity.ConnectionString =tenantServiceProvider.GeneratTenant(request.TenantName,cancellationToken);
                    await  tenantDbContext.Tenants.AddAsync(entity,cancellationToken);
                }
                entity.TenantName = request.TenantName;
                entity.TenantLogo = request.TenantLogo;
                await tenantDbContext.SaveChangesAsync(cancellationToken);
                
                return entity.Id;
            }
        }
    }
}
