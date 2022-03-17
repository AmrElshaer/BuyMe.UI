using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using Newtonsoft.Json;
using System;
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
            public UpSertTenantCommondHandler(ITenantDbContext tenantDbContext,ITenantServiceProvider tenantServiceProvider)
            {
                this.tenantDbContext = tenantDbContext;
                this.tenantServiceProvider = tenantServiceProvider;
            }
            public async Task<int> Handle(UpSertTenantCommond request, CancellationToken cancellationToken)
            {
                Domain.Entities.Tenant entity;
                string tenantEvent = string.Empty;
                if (request.Id.HasValue)
                {
                    var tenant = await tenantDbContext.Tenants.FindAsync(request.Id, cancellationToken);
                    Guard.Against.Null(tenant, request.Id);
                    entity = tenant;
                    tenantEvent = TenantEvent.Updated;

                }
                else
                {
                    entity = new Domain.Entities.Tenant();
                    entity.ConnectionString = tenantServiceProvider.GeneratTenant(request.TenantName, cancellationToken);
                    await tenantDbContext.Tenants.AddAsync(entity, cancellationToken);
                    tenantEvent = TenantEvent.Created;
                }
                entity.TenantName = request.TenantName;
                entity.TenantLogo = request.TenantLogo;
                await tenantDbContext.OutboxMessages.AddAsync(CreatOutBoxMessage(request.TenantName, tenantEvent));
                await tenantDbContext.SaveChangesAsync(cancellationToken);
                return entity.Id;
            }

            private  Domain.Entities.OutboxMessage CreatOutBoxMessage(string tenantName, string tenantEvent)
            {
                return new Domain.Entities.OutboxMessage(Guid.NewGuid(), DateTime.Now, tenantEvent, JsonConvert.SerializeObject(new TenantEvent { Name = tenantName }));
            }
        }
    }
}
