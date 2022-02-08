using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.InvoiceType.Commonds.CreatEditIInvoiceType
{
    public class CreatEditInvoiceTypeCommond : IRequest<int>
    {
        public int? InvoiceTypeId { get; set; }
        public string InvoiceTypeName { get; set; }
        public string Description { get; set; }
        public class CreatEditInvoiceTypeCommondHandler : IRequestHandler<CreatEditInvoiceTypeCommond, int>
        {
            private readonly IBuyMeDbContext _context;
           
            public CreatEditInvoiceTypeCommondHandler(IBuyMeDbContext context)
            {
                this._context = context;
            }
            public async Task<int> Handle(CreatEditInvoiceTypeCommond request, CancellationToken cancellationToken)
            {
                Domain.Entities.InvoiceType invoiceType;
                if (request.InvoiceTypeId.HasValue)
                {
                    var entity = await _context.InvoiceTypes.FindAsync(request.InvoiceTypeId);
                    Guard.Against.Null(entity, request.InvoiceTypeId);
                    invoiceType = entity;
                }
                else
                {
                    invoiceType = new Domain.Entities.InvoiceType();
                    _context.InvoiceTypes.Add(invoiceType);
                }
                invoiceType.InvoiceTypeName = request.InvoiceTypeName;
                invoiceType.Description = request.Description;
                await _context.SaveChangesAsync();
                return invoiceType.InvoiceTypeId;
            }
        }
    }
}
