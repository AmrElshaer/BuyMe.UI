using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.PaymentReceive.Commonds.DeletPaymentReceive
{
    public  class DeletPaymentReceiveCommond:IRequest<Unit>
    {
        public int PaymentReceiveId { get; set; }
        public class DeletPaymentReceiveCommondHandler : IRequestHandler<DeletPaymentReceiveCommond, Unit>
        {
            private readonly IBuyMeDbContext buyMeDbContext;

            public DeletPaymentReceiveCommondHandler(IBuyMeDbContext buyMeDbContext)
            {
                this.buyMeDbContext = buyMeDbContext;
            }
            public async Task<Unit> Handle(DeletPaymentReceiveCommond request, CancellationToken cancellationToken)
{
                var entity = await buyMeDbContext.PaymentReceives.FindAsync(request.PaymentReceiveId);
                Guard.Against.Null(entity, request.PaymentReceiveId);
                buyMeDbContext.PaymentReceives.Remove(entity);
                await buyMeDbContext.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
