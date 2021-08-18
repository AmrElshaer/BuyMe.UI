using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.SalesOrderLine.Commonds.DeleteSOLine
{
    public class DeleteSOLineCommond : IRequest<Unit>
    {
        public int SalesOrderLineId { get; set; }

        public class DeleteSOLineCommondHandler : IRequestHandler<DeleteSOLineCommond, Unit>
        {
            private readonly IBuyMeDbContext _context;
            private readonly ISalesOrderService _salesOrderService;

            public DeleteSOLineCommondHandler(IBuyMeDbContext context, ISalesOrderService salesOrderService)
            {
                this._context = context;
                this._salesOrderService = salesOrderService;
            }

            public async Task<Unit> Handle(DeleteSOLineCommond request, CancellationToken cancellationToken)
            {
                var soLine = await _context.SalesOrderLines.FindAsync(request.SalesOrderLineId);
                Guard.Against.Null(soLine, request.SalesOrderLineId);
                _context.SalesOrderLines.Remove(soLine);
                await _context.SaveChangesAsync(cancellationToken);
                await _salesOrderService.UpdateSalesOrderAsync(soLine.SalesOrderId);
                return Unit.Value;
            }
        }
    }
}