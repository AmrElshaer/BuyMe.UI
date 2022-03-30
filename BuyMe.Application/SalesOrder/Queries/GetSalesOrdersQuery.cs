using System.Collections.Generic;
using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.SalesOrder.Queries
{
    public class GetSalesOrdersQuery :BaseRequestQuery, IRequest<QueryResult<SalesOrderDto>>
    {
    

        public class GetSalesOrderQueryHandler : IRequestHandler<GetSalesOrdersQuery, QueryResult<SalesOrderDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetSalesOrderQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QueryResult<SalesOrderDto>> Handle(GetSalesOrdersQuery request, CancellationToken cancellationToken)
            {
                var res =await _context.SalesOrders
                    .Include(a => a.Branch)
                    .Include(a => a.Customer)
                    .Include(a => a.Currency)
                    .Include(a => a.SalesType)
                    .ApplyFiliter(request,a =>
                    a.SalesOrderName.Contains(request.DM.SearchValue)
                    ).ApplySkip(request).ApplyTake(request)
                    .Build(a => a.SalesOrderId) ;
                return new QueryResult<SalesOrderDto>() { count = res.Count, result =_mapper.Map<IList<SalesOrderDto>>(res.Data)  };
            }
        }
    }
}