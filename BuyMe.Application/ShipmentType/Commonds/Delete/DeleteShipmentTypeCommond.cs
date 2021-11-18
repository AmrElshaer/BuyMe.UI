using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.ShipmentType.Commonds.Delete
{
    public class DeleteShipmentTypeCommond : IRequest<Unit>
    {
        public int ShipmentTypeId { get; set; }

        public class DeleteShipmentTypeCommondHandler : IRequestHandler<DeleteShipmentTypeCommond, Unit>
        {
            private readonly IBuyMeDbContext _context;

            public DeleteShipmentTypeCommondHandler(IBuyMeDbContext context)
            {
                this._context = context;
            }

            public async Task<Unit> Handle(DeleteShipmentTypeCommond request, CancellationToken cancellationToken)
            {
                var shipmentType = await _context.ShipmentTypes.FindAsync(request.ShipmentTypeId);
                Guard.Against.Null(shipmentType, request.ShipmentTypeId);
                _context.ShipmentTypes.Remove(shipmentType);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}