using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Invoice.Commonds.CreatEditInvoice
{
    public class UpSertInvoiceCommond:IRequest<int>
{
        public int? InvoiceId { get; set; }
        
        public string InvoiceName { get; set; }
      
        public int ShipmentId { get; set; }
       
        public DateTime InvoiceDate { get; set; }
       
        public DateTime InvoiceDueDate { get; set; }
       
        public int? InvoiceTypeId { get; set; }
        public class UpSertInvoiceCommondHandler : IRequestHandler<UpSertInvoiceCommond, int>
        {
            private readonly IBuyMeDbContext _context;
            private readonly INumberSequencyService _numberSequencyService;

            public UpSertInvoiceCommondHandler(IBuyMeDbContext context, INumberSequencyService numberSequencyService)
            {
                this._context = context;
                this._numberSequencyService = numberSequencyService;
            }
            public async Task<int> Handle(UpSertInvoiceCommond request, CancellationToken cancellationToken)
            {
                Domain.Entities.Invoice invoice;
                if (request.InvoiceId.HasValue)
                {
                    var entity = await _context.Invoices.FindAsync(request.InvoiceId);
                    Guard.Against.Null(entity, request.InvoiceId);
                    invoice = entity;
                }
                else
                {
                    invoice = new Domain.Entities.Invoice();
                    invoice.InvoiceName= await _numberSequencyService.GetCurrentNumberSequence("INV");
                    await this._context.Invoices.AddAsync(invoice);
                }
                invoice.ShipmentId = request.ShipmentId;
                invoice.InvoiceTypeId = request.InvoiceTypeId;
                invoice.InvoiceDate = request.InvoiceDate;
                invoice.InvoiceDueDate = request.InvoiceDueDate;
                await _context.SaveChangesAsync();
                return invoice.InvoiceId;
            }
        }
    }
}
