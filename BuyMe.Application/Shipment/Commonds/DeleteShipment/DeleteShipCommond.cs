using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.SalesOrder.Commonds.DeleteSalesOrder
{
    public class DeleteShipCommond : IRequest<Unit>
    {
        public long ShipmentId { get; set; }

        public class DeleteDeleteShipCommondCommondHandler : IRequestHandler<DeleteShipCommond, Unit>
        {
            private readonly IBuyMeDbContext _context;

            public DeleteDeleteShipCommondCommondHandler(IBuyMeDbContext context)
            {
                this._context = context;
            }

            public async Task<Unit> Handle(DeleteShipCommond request, CancellationToken cancellationToken)
            {
                var shipment = await _context.Shipments.FindAsync(request.ShipmentId);
                Guard.Against.Null(shipment, request.ShipmentId);
                _context.Shipments.Remove(shipment);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}