using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.PaymentType.Commonds.DeletCommond
{
    public  class DeletePaymentTypeCommond:IRequest<Unit>
    {
        public int? PaymentTypeId { get; set; }
        public class DeletePaymentTypeCommondHandler : IRequestHandler<DeletePaymentTypeCommond, Unit>
        {
            private readonly IBuyMeDbContext context;

            public DeletePaymentTypeCommondHandler(IBuyMeDbContext context)
            {
                this.context = context;
            }
            public async Task<Unit> Handle(DeletePaymentTypeCommond request, CancellationToken cancellationToken)
            {
                var entity = await context.PaymentTypes.FindAsync(request.PaymentTypeId);
                Guard.Against.Null(entity, request.PaymentTypeId);
                context.PaymentTypes.Remove(entity);
                await context.SaveChangesAsync();
                return Unit.Value;
            }
        }

    }
}
