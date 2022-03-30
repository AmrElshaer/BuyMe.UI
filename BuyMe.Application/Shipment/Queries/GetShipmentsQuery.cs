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
    public class GetShipmentsQuery:BaseRequestQuery,IRequest<QueryResult<ShipmentDto>>
    {
       

        public class GetSalesOrderQueryHandler : IRequestHandler<GetShipmentsQuery, QueryResult<ShipmentDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;
            

            public GetSalesOrderQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
               
            }

            public async Task<QueryResult<ShipmentDto>> Handle(GetShipmentsQuery request, CancellationToken cancellationToken)
            {
                var res =await _context.Shipments.Include(a => a.Warehouse)
                    .Include(a=>a.SalesOrder)
                    .ApplyFiliter(request,a =>
                    a.ShipmentName.Contains(request.DM.SearchValue)
                    ).ApplySkip(request).ApplyTake(request).Build(a=>a.ShipmentId);
                return new QueryResult<ShipmentDto>() { count = res.Count, result =_mapper.Map<IList<ShipmentDto> >(
                    res.Data) };
            }
        }
    }
}
