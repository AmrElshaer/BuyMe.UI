using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.SalesOrder.Queries
{
    public class GetSalesOrderQuery : IRequest<SalesOrderDto>
    {
        public long SalesOrderId { get; private set; }

        public GetSalesOrderQuery(long salesOrderId)
        {
            SalesOrderId = salesOrderId;
        }

        public class GetSalesOrderByIdQueryHandler : IRequestHandler<GetSalesOrderQuery, SalesOrderDto>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService currentUserService;

            public GetSalesOrderByIdQueryHandler(IBuyMeDbContext context, IMapper mapper, ICurrentUserService currentUserService)
            {
                _context = context;
                _mapper = mapper;
                this.currentUserService = currentUserService;
            }

            public async Task<SalesOrderDto> Handle(GetSalesOrderQuery request, CancellationToken cancellationToken)
            {
                var salesOrder = await _context.SalesOrders.Include(a => a.Branch).Include(a => a.Customer).Include(a => a.Currency)
                    .Include(a => a.SalesType).FirstOrDefaultAsync(a => a.CompanyId == currentUserService.CompanyId
                    && a.SalesOrderId == request.SalesOrderId);
                return _mapper.Map<SalesOrderDto>(salesOrder);
            }
        }
    }
}