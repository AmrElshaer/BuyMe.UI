using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.SalesOrder.Commonds.DeleteSalesOrder
{
    public class DeleteSalesOrderCommond : IRequest<Unit>
    {
        public long SalesOrderId { get; set; }

        public class DeleteSalesOrderCommondHandler : IRequestHandler<DeleteSalesOrderCommond, Unit>
        {
            private readonly IBuyMeDbContext _context;

            public DeleteSalesOrderCommondHandler(IBuyMeDbContext context)
            {
                this._context = context;
            }

            public async Task<Unit> Handle(DeleteSalesOrderCommond request, CancellationToken cancellationToken)
            {
                var so = await _context.SalesOrders.FindAsync(request.SalesOrderId);
                Guard.Against.Null(so, request.SalesOrderId);
                _context.SalesOrders.Remove(so);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}