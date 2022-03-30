using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Company.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.TenantSetting.Queries
{
    public class GetAllTenantQuery:BaseRequestQuery,IRequest<QueryResult<TenantDto>>
    {
      
        public class GetAllTenantQueryHandler : IRequestHandler<GetAllTenantQuery, QueryResult<TenantDto>>
        {
            private readonly ITenantDbContext tenantDbContext;
            private readonly IMapper mapper;

            public GetAllTenantQueryHandler(ITenantDbContext tenantDbContext, IMapper mapper)
            {
                this.tenantDbContext = tenantDbContext;
                this.mapper = mapper;
            }
            public async Task<QueryResult<TenantDto>> Handle(GetAllTenantQuery request, CancellationToken cancellationToken)
            {
                var res =await tenantDbContext.Tenants
                    .ApplyFiliter(request, a => a.TenantName.Contains(request.DM.SearchValue))
                    .ApplySkip(request).ApplyTake(request).Build(a => a.Id);
                return new QueryResult<TenantDto>() { count = res.Count, 
                    result = mapper.Map<IList<TenantDto>>(res.Data) };
               
            }
        }
    }
}
