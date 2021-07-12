using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Customer.Commonds.DeleteCustomer
{
    public class DeleteCustomerCommond : IRequest<Unit>
    {
        public int CustomerId { get; set; }

        public class DeleteCustomerCommondHandler : IRequestHandler<DeleteCustomerCommond, Unit>
        {
            private readonly IBuyMeDbContext _context;

            public DeleteCustomerCommondHandler(IBuyMeDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteCustomerCommond request, CancellationToken cancellationToken)
            {
                var customer = await _context.Customers.FindAsync(request.CustomerId);
                _ = customer ?? throw new NotFoundException(nameof(Domain.Entities.Customer), request.CustomerId);
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}