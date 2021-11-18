using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using BuyMe.Application.SalesOrder.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Shipment.Queries
{
    public class GetShipmentsQuery:IRequest<QueryResult<ShipmentDto>>
    {
        public DataManager DM { get; set; }

        public GetShipmentsQuery()
        {
            DM ??= new DataManager();
        }

        public class GetSalesOrderQueryHandler : IRequestHandler<GetShipmentsQuery, QueryResult<ShipmentDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService currentUserService;

            public GetSalesOrderQueryHandler(IBuyMeDbContext context, IMapper mapper, ICurrentUserService currentUserService)
            {
                _context = context;
                _mapper = mapper;
                this.currentUserService = currentUserService;
            }

            public async Task<QueryResult<ShipmentDto>> Handle(GetShipmentsQuery request, CancellationToken cancellationToken)
            {
                var dataSource = _context.Shipments.Include(a => a.Warehouse)
                    .Where(a => a.CompanyId == currentUserService.CompanyId).AsQueryable();
                if (!string.IsNullOrEmpty(request.DM.SearchValue))
                {
                    dataSource = dataSource.Where(a =>
                    a.ShipmentName.Contains(request.DM.SearchValue)
                    );
                }
                if (request.DM.Skip != null && request.DM.Skip != 0) dataSource = dataSource.Skip(request.DM.Skip.Value);
                if (request.DM.Take != null && request.DM.Take != 0) dataSource = dataSource.Take(request.DM.Take.Value);
                int count = dataSource.Count();
                var products = dataSource.OrderByDescending(a => a.ShipmentId).Select(_mapper.Map<ShipmentDto>).ToList();
                return new QueryResult<ShipmentDto>() { count = count, result = products };
            }
        }
    }
}
