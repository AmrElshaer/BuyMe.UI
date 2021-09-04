using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.WarehouseINV.Commonds.CreatEdit
{
    public class CreatEditWarhouseCommondHandler : IRequestHandler<CreatEditWarehouseCommond, int>
    {
        private readonly IBuyMeDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public CreatEditWarhouseCommondHandler(IBuyMeDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(CreatEditWarehouseCommond request, CancellationToken cancellationToken)
        {
            Warehouse warehouse;
            if (request.WarehouseId.HasValue)
            {
                var entity = await _context.Warehouses.FindAsync(request.WarehouseId);
                Guard.Against.Null(entity, request.WarehouseId);
                warehouse = entity;
            }
            else
            {
                warehouse = new Warehouse();
                await _context.Warehouses.AddAsync(warehouse);
                warehouse.CompanyId = _currentUserService.CompanyId;
            }
            warehouse.Description = request.Description;
            warehouse.BranchId = request.BranchId;
            warehouse.WarehouseName = request.WarehouseName;

            await _context.SaveChangesAsync(cancellationToken);
            return warehouse.WarehouseId;
        }
    }
}