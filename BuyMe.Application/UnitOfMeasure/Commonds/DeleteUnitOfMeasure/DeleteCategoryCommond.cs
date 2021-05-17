using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.UnitOfMeasure.Commonds.DeleteUnitOfMeasure
{
    public class DeleteUnitOfMeasureCommond:IRequest<Unit>
    {
        public int UOMId  { get; set; }
        public class DeleteUOMCommondHandler : IRequestHandler<DeleteUnitOfMeasureCommond, Unit>
        {
            private readonly IBuyMeDbContext _context;

            public DeleteUOMCommondHandler(IBuyMeDbContext context)
            {
                this._context = context;
            }
            public async Task<Unit> Handle(DeleteUnitOfMeasureCommond request, CancellationToken cancellationToken)
            {
                var uom =await _context.UnitOfMeasures.FindAsync(request.UOMId);
                _ = uom ?? throw new NotFoundException(nameof(Domain.Entities.Company), request.UOMId);
                _context.UnitOfMeasures.Remove(uom);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            } 
        }
    }
}
