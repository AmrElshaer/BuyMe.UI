using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.ShipmentType.Commonds.CreateEdit
{
    public class CreatEditShipmentTypeCommond : IRequest<int>
    {
        public int? Id { get; set; }
        public string ShipmentTypeName { get; set; }
        public string ShipmentTypeDescription { get; set; }
        public string CompanyId { get; set; }

        public class CreatEditShipmentTypeCommondHandler : IRequestHandler<CreatEditShipmentTypeCommond, int>
        {
            private readonly IBuyMeDbContext _context;
            private readonly ICurrentUserService _currentUserService;

            public CreatEditShipmentTypeCommondHandler(IBuyMeDbContext context, ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUserService = currentUserService;
            }

            public async Task<int> Handle(CreatEditShipmentTypeCommond request, CancellationToken cancellationToken)
            {
                Domain.Entities.ShipmentType shipmentType;
                if (request.Id.HasValue)
                {
                    var entity = await _context.ShipmentTypes.FindAsync(request.Id);
                    Guard.Against.Null(entity, request.Id);
                    shipmentType = entity;
                }
                else
                {
                    shipmentType = new Domain.Entities.ShipmentType();
                    await _context.ShipmentTypes.AddAsync(shipmentType);
                    shipmentType.CompanyId = _currentUserService.CompanyId;
                }
                shipmentType.ShipmentTypeDescription = request.ShipmentTypeDescription;
                shipmentType.ShipmentTypeName = request.ShipmentTypeName;
                await _context.SaveChangesAsync(cancellationToken);
                return shipmentType.Id;
            }
        }
    }
}