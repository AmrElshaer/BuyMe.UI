using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.SalesType.Commonds.Delete
{
    public class DeleteSalesTypeCommond:IRequest<Unit>
    {
        public int SalesTypeId { get; set; }
        public class DeleteSalesTypeCommondHandler : IRequestHandler<DeleteSalesTypeCommond, Unit>
        {
            private readonly IBuyMeDbContext _context;

            public DeleteSalesTypeCommondHandler(IBuyMeDbContext context)
            {
                this._context = context;
            }
            public async Task<Unit> Handle(DeleteSalesTypeCommond request, CancellationToken cancellationToken)
            {
                var customerType = await _context.SalesTypes.FindAsync(request.SalesTypeId);
                _ = customerType ?? throw new NotFoundException(nameof(Domain.Entities.SalesType), request.SalesTypeId);
                _context.SalesTypes.Remove(customerType);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
