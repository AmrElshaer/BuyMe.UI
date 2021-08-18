using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Currency.Commonds.CreateEditCurrency
{
    public class CreatEditCurrencyCommondHandler : IRequestHandler<CreatEditCurrencyCommond, int>
    {
        private readonly IBuyMeDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public CreatEditCurrencyCommondHandler(IBuyMeDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(CreatEditCurrencyCommond request, CancellationToken cancellationToken)
        {
            Domain.Entities.Currency currency;
            if (request.CurrencyId.HasValue)
            {
                var entity = await _context.Currencies.FindAsync(request.CurrencyId);
                Guard.Against.Null(entity, request.CurrencyId);
                currency = entity;
            }
            else
            {
                currency = new Domain.Entities.Currency();
                currency.CompanyId = _currentUserService.CompanyId;
                await _context.Currencies.AddAsync(currency);
            }
            currency.CurrencyName = request.CurrencyName;
            currency.CurrencyCode = request.CurrencyCode;
            currency.Description = request.Description;
            await _context.SaveChangesAsync(cancellationToken);
            return currency.CurrencyId;
        }
    }
}