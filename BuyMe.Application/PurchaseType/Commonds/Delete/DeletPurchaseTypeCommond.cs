using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.PurchaseType.Commonds.Delete
{
    public class DeletPurchaseTypeCommond:IRequest<Unit>
    {
        public int? PurchaseTypeId { get; set; }
        public class DeletPurchaseTypeCommondHandler : IRequestHandler<DeletPurchaseTypeCommond, Unit>
        {
            private readonly IBuyMeDbContext _context;

            public DeletPurchaseTypeCommondHandler(IBuyMeDbContext context)
            {
                this._context = context;
            }

            public async Task<Unit> Handle(DeletPurchaseTypeCommond request, CancellationToken cancellationToken)
            {
                var purchaseType = await _context.PurchaseTypes.FindAsync(request.PurchaseTypeId);
                Guard.Against.Null(purchaseType, request.PurchaseTypeId);
                _context.PurchaseTypes.Remove(purchaseType);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
