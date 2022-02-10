using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Invoice.Commonds.DeleteInvoice
{
    public class DeleteInvoiceCommond:IRequest<Unit>
    {
        public int InvoiceId { get; set; }
        public class DeleteInvoiceCommondHandler : IRequestHandler<DeleteInvoiceCommond, Unit>
        {
            private readonly IBuyMeDbContext buyMeDbContext;

            public DeleteInvoiceCommondHandler(IBuyMeDbContext buyMeDbContext)
            {
                this.buyMeDbContext = buyMeDbContext;
            }
            public async Task<Unit> Handle(DeleteInvoiceCommond request, CancellationToken cancellationToken)
            {
                var entity =await buyMeDbContext.Invoices.FindAsync(request.InvoiceId);
                Guard.Against.Null(entity,request.InvoiceId);
                buyMeDbContext.Invoices.Remove(entity);
                await buyMeDbContext.SaveChangesAsync();
                return Unit.Value;

            }
        }
    }
}
