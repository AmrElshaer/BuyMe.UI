using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.InvoiceType.Commonds.CreatEditIInvoiceType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.PaymentType.Commonds.CreatEditCommond
{
    public class CreatEditPaymentTypeCommond:IRequest<int>
    {
        public int? PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public string Description { get; set; }
        public class CreatEditPaymentTypeCommondHandler : IRequestHandler<CreatEditPaymentTypeCommond, int>
        {
            private readonly IBuyMeDbContext _context;

            public CreatEditPaymentTypeCommondHandler(IBuyMeDbContext context)
            {
                this._context = context;
            }
            public async Task<int> Handle(CreatEditPaymentTypeCommond request, CancellationToken cancellationToken)
            {
                Domain.Entities.PaymentType paymentType;
                if (request.PaymentTypeId.HasValue)
                {
                    var entity = await _context.PaymentTypes.FindAsync(request.PaymentTypeId);
                    Guard.Against.Null(entity, request.PaymentTypeId);
                    paymentType = entity;
                }
                else
                {
                    paymentType = new Domain.Entities.PaymentType();
                    _context.PaymentTypes.Add(paymentType);
                }
                paymentType.PaymentTypeName = request.PaymentTypeName;
                paymentType.Description = request.Description;
                await _context.SaveChangesAsync();
                return paymentType.PaymentTypeId;
            }
        }
    }
}
