using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.WarehouseINV.Commonds.DeleteWarehouse
{
    public class DeleteWarehouseCommond:IRequest<Unit>
    {
        public int WarehouseId { get; set; }
        public class DeleteWarehouseCommondHandler : IRequestHandler<DeleteWarehouseCommond, Unit>
        {
            private readonly IBuyMeDbContext _context;

            public DeleteWarehouseCommondHandler(IBuyMeDbContext context)
            {
                this._context = context;
            }
            public async Task<Unit> Handle(DeleteWarehouseCommond request, CancellationToken cancellationToken)
            {
                var warehouse = await _context.Warehouses.FindAsync(request.WarehouseId);
                _ = warehouse ?? throw new NotFoundException(nameof(Domain.Entities.Warehouse), request.WarehouseId);
                _context.Warehouses.Remove(warehouse);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
