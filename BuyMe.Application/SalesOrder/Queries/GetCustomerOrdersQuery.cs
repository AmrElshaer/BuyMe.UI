using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.SalesOrder.Queries
{
    public class GetCustomerOrdersQuery:IRequest<IList<SalesOrderDto>>
    {
        public int CustomerId { get; }
        public GetCustomerOrdersQuery(int customerId)
        {
            CustomerId = customerId;
        }

        public class GetCustomerOrdersQueryHandler : IRequestHandler<GetCustomerOrdersQuery, IList<SalesOrderDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService currentUserService;

            public GetCustomerOrdersQueryHandler(IBuyMeDbContext context, IMapper mapper, ICurrentUserService currentUserService)
            {
                _context = context;
                _mapper = mapper;
                this.currentUserService = currentUserService;
            }

            public async Task<IList<SalesOrderDto>> Handle(GetCustomerOrdersQuery request, CancellationToken cancellationToken)
            {
                var orders =await _context.SalesOrders.Include(a => a.Branch).Include(a => a.Currency)
                    .Include(a=>a.SalesOrderLines).ThenInclude(a=>a.Product).ThenInclude(a=>a.ProductImages)
                    .OrderByDescending(a=>a.SalesOrderId)
                    .Where(a => a.CustomerId==request.CustomerId&&a.CompanyId == currentUserService.CompanyId).ToListAsync();
                return  _mapper.Map<IList<SalesOrderDto>>(orders);
            }
        }
    }
}
