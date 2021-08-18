using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.UnitOfMeasure.Commonds
{
    public class CreateEditUnitOfMeasureCommondHandler : IRequestHandler<CreateEditUnitOfMeasureCommond, int>
    {
        private readonly IBuyMeDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public CreateEditUnitOfMeasureCommondHandler(IBuyMeDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(CreateEditUnitOfMeasureCommond request, CancellationToken cancellationToken)
        {
            Domain.Entities.UnitOfMeasure uom;
            if (request.Id.HasValue)
            {
                var entity = await _context.UnitOfMeasures.FindAsync(request.Id);
                Guard.Against.Null(entity, request.Id);
                uom = entity;
            }
            else
            {
                uom = new Domain.Entities.UnitOfMeasure();
                await _context.UnitOfMeasures.AddAsync(uom);
                uom.CompanyId = _currentUserService.CompanyId;
            }
            uom.UOM = request.UOM;
            uom.Description = request.Description;
            await _context.SaveChangesAsync(cancellationToken);
            return uom.Id;
        }
    }
}