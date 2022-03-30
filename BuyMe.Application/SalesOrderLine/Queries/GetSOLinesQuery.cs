using System.Collections.Generic;
using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.SalesOrderLine.Queries
{
    public class GetSOLinesQuery : BaseRequestQuery,IRequest<QueryResult<SalesOrderLineDto>>
    {
     
        public long SalesOrderId { get;  }

        public GetSOLinesQuery(long salesOrderId)
        {
            SalesOrderId = salesOrderId;
        }

        public class GetSalesOrderQueryHandler : IRequestHandler<GetSOLinesQuery, QueryResult<SalesOrderLineDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetSalesOrderQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QueryResult<SalesOrderLineDto>> Handle(GetSOLinesQuery request, CancellationToken cancellationToken)
            {
                var res =await _context.SalesOrderLines
                    .Include(a => a.Product)
                    .Where(a => a.SalesOrderId == request.SalesOrderId)
                    .ApplyFiliter(request,a =>
                    a.Product.ProductName.Contains(request.DM.SearchValue)
                    ).ApplySkip(request).ApplyTake(request).Build(a => a.SalesOrderLineId);
                    
                return new QueryResult<SalesOrderLineDto>() { count = res.Count, 
                    result =_mapper.Map<IList<SalesOrderLineDto>>(
                    res.Data) };
            }
        }
    }
}