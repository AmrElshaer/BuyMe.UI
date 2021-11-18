using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Shipment.Commonds
{
    public class CreateEditShipCommondHandler : IRequestHandler<CreateEditShipCommond, long>
    {
        private readonly IBuyMeDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly INumberSequencyService _numberSequencyService;

        public CreateEditShipCommondHandler(IBuyMeDbContext context, ICurrentUserService currentUserService, INumberSequencyService numberSequencyService)
        {
            _context = context;
            _currentUserService = currentUserService;
            _numberSequencyService = numberSequencyService;
        }

        public async Task<long> Handle(CreateEditShipCommond request, CancellationToken cancellationToken)
        {
            Domain.Entities.Shipment ship;
            if (request.ShipmentId.HasValue)
            {
                var entity = await _context.Shipments.FindAsync(request.ShipmentId);
                Guard.Against.Null(entity, request.ShipmentId);
                ship = entity;
            }
            else
            {
                ship = new Domain.Entities.Shipment();
                ship.CompanyId = _currentUserService.CompanyId;
                ship.ShipmentName = await _numberSequencyService.GetCurrentNumberSequence("ship");
                await _context.Shipments.AddAsync(ship);
            }
            ship.ShipmentDate = request.ShipmentDate;
            ship.SalesOrderId = request.SalesOrderId;
            ship.ShipmentTypeId = request.ShipmentTypeId;
            ship.WarehouseId = request.WarehouseId;
            ship.Remarks = request.Remarks;
            await _context.SaveChangesAsync(cancellationToken);
            return ship.ShipmentId;
        }
    }
}