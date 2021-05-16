using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Currency.Commonds.DeleteCurrency
{
    public class DeleteCurrencyCommond:IRequest<Unit>
    {
        public int CurrencyId { get; set; }
        public class DeleteEmployeeCommondHandler : IRequestHandler<DeleteCurrencyCommond,Unit>
        {
            private readonly IBuyMeDbContext context;
            public DeleteEmployeeCommondHandler(IBuyMeDbContext context)
            {
                this.context = context;
            }
            public async Task<Unit> Handle(DeleteCurrencyCommond request, CancellationToken cancellationToken)
            {
                var currency = await context.Currencies.FindAsync(request.CurrencyId);
                if (currency == null)
                {
                    throw new NotFoundException(nameof(Currency), request.CurrencyId);
                }
                context.Currencies.Remove(currency);
                await context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
