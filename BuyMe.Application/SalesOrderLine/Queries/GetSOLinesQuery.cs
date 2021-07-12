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
    public class GetSOLinesQuery : IRequest<QueryResult<SalesOrderLineDto>>
    {
        public DataManager DM { get; set; }
        public long SalesOrderId { get; private set; }

        public GetSOLinesQuery(long salesOrderId)
        {
            DM ??= new DataManager();
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
                var dataSource = _context.SalesOrderLines.Include(a => a.Product)
                    .Where(a => a.SalesOrderId == request.SalesOrderId).AsQueryable();
                if (!string.IsNullOrEmpty(request.DM.SearchValue))
                {
                    dataSource = dataSource.Where(a =>
                    a.Product.ProductName.Contains(request.DM.SearchValue)
                    );
                }
                if (request.DM.Skip != null && request.DM.Skip != 0) dataSource = dataSource.Skip(request.DM.Skip.Value);
                if (request.DM.Take != null && request.DM.Take != 0) dataSource = dataSource.Take(request.DM.Take.Value);
                int count = dataSource.Count();
                var products = dataSource.OrderByDescending(a => a.SalesOrderLineId).Select(_mapper.Map<SalesOrderLineDto>).ToList();
                return new QueryResult<SalesOrderLineDto>() { count = count, result = products };
            }
        }
    }
}