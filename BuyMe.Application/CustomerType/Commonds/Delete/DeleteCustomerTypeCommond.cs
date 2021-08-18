using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.CustomerType.Commonds.Delete
{
    public class DeleteCustomerTypeCommond : IRequest<Unit>
    {
        public int CustomerTypeId { get; set; }

        public class DeleteSalesTypeCommondHandler : IRequestHandler<DeleteCustomerTypeCommond, Unit>
        {
            private readonly IBuyMeDbContext _context;

            public DeleteSalesTypeCommondHandler(IBuyMeDbContext context)
            {
                this._context = context;
            }

            public async Task<Unit> Handle(DeleteCustomerTypeCommond request, CancellationToken cancellationToken)
            {
                var customerType = await _context.CustomerTypes.FindAsync(request.CustomerTypeId);
                Guard.Against.Null(customerType, request.CustomerTypeId);
                _context.CustomerTypes.Remove(customerType);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}