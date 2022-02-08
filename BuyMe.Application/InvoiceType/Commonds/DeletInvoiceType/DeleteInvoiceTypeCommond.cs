using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.InvoiceType.Commonds.DeletInvoiceType
{
    public class DeleteInvoiceTypeCommond:IRequest<Unit>
    {
        public int InvoiceTypeId { get; set; }
        public class DeleteInvocieTypeCommondHandler : IRequestHandler<DeleteInvoiceTypeCommond, Unit>
        {
            private readonly IBuyMeDbContext context;

            public DeleteInvocieTypeCommondHandler(IBuyMeDbContext context)
            {
                this.context = context;
            }
            public async Task<Unit> Handle(DeleteInvoiceTypeCommond request, CancellationToken cancellationToken)
            {
                var entity = await context.InvoiceTypes.FindAsync(request.InvoiceTypeId);
                Guard.Against.Null(entity,request.InvoiceTypeId);
                context.InvoiceTypes.Remove(entity);
                await context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
