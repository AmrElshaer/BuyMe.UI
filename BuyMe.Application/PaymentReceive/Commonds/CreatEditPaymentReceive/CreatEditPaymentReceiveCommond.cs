using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.PaymentReceive.Commonds.CreatEditPaymentReceive
{
    public  class CreatEditPaymentReceiveCommond:IRequest<int>
    {
        public int? PaymentReceiveId { get; set; }
        public string PaymentReceiveName { get; set; }
        public int InvoiceId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentTypeId { get; set; }

        public double PaymentAmount { get; set; }
        public bool IsFullPayment { get; set; } = true;
        public class CreatEditPaymentReceiveCommondHandler : IRequestHandler<CreatEditPaymentReceiveCommond, int>
        {
            private readonly IBuyMeDbContext _context;
            private readonly INumberSequencyService _numberSequencyService;

            public CreatEditPaymentReceiveCommondHandler(IBuyMeDbContext context, INumberSequencyService numberSequencyService)
            {
                this._context = context;
                this._numberSequencyService = numberSequencyService;
            }
            public async Task<int> Handle(CreatEditPaymentReceiveCommond request, CancellationToken cancellationToken)
            {
                Domain.Entities.PaymentReceive payrec;
                if (request.PaymentReceiveId.HasValue)
                {
                    var entity = await _context.PaymentReceives.FindAsync(request.PaymentReceiveId);
                    Guard.Against.Null(entity, request.PaymentReceiveId);
                    payrec = entity;
                }
                else
                {
                    payrec = new Domain.Entities.PaymentReceive();
                    payrec.PaymentReceiveName = await _numberSequencyService.GetCurrentNumberSequence("PAYRCV");
                    await this._context.PaymentReceives.AddAsync(payrec);
                }
                payrec.PaymentTypeId = request.PaymentTypeId;
                payrec.InvoiceId = request.InvoiceId;
                payrec.PaymentAmount = request.PaymentAmount;
                payrec.IsFullPayment = request.IsFullPayment;
                payrec.PaymentDate = request.PaymentDate;
                await _context.SaveChangesAsync();
                return payrec.PaymentReceiveId;
            }
        }
    }
}
