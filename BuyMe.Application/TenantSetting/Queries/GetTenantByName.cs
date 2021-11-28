using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetTenantByNameQuery:IRequest<TenantDto>
{
   public string TenantName { get; set; }
    public class GetTenantByNameQueryHandler : IRequestHandler<GetTenantByNameQuery, TenantDto>
    {
        private readonly ITenantDbContext tenantDbContext;
        private readonly IMapper mapper;

        public GetTenantByNameQueryHandler(ITenantDbContext tenantDbContext,IMapper mapper)
        {
            this.mapper = mapper;
            this.tenantDbContext = tenantDbContext;
        }
        public async Task<TenantDto> Handle(GetTenantByNameQuery request, CancellationToken cancellationToken)
        {
           var tenant=await tenantDbContext.Tenants.FirstOrDefaultAsync(a=>a.TenantName==request.TenantName);
            return this.mapper.Map<TenantDto>(tenant);
        }
    }
}