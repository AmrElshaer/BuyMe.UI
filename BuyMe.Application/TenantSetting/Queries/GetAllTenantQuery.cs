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
    public class GetAllTenantQuery:IRequest<QueryResult<TenantDto>>
    {
        public DataManager DM { get; set; }

        public GetAllTenantQuery()
        {
            DM ??= new DataManager();
        }
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
                var dataSource = tenantDbContext.Tenants.AsQueryable();
                if (!string.IsNullOrEmpty(request.DM.SearchValue))
                {
                    dataSource = dataSource.Where(a => a.TenantName.Contains(request.DM.SearchValue) );
                  
                }
                if (request.DM.Skip != null && request.DM.Skip != 0) dataSource = dataSource.Skip(request.DM.Skip.Value);
                if (request.DM.Take != null && request.DM.Take != 0) dataSource = dataSource.Take(request.DM.Take.Value);
                int count = dataSource.Count();
                var allTenants = dataSource.OrderByDescending(a => a.Id).Select(mapper.Map<TenantDto>).ToList();
                return new QueryResult<TenantDto>() { count = count, result = allTenants };
               
            }
        }
    }
}
