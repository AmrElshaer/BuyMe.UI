using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.MarketingDefaultSetting.Commonds
{
    public class CreateEditMakDefSettHandler : IRequestHandler<CreateEditMakDefSett, int>
    {
        private readonly IBuyMeDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public CreateEditMakDefSettHandler(IBuyMeDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }
        public async Task<int> Handle(CreateEditMakDefSett request, CancellationToken cancellationToken)
        {
            Domain.Entities.MarketingDefaultSetting marketingDefaultSetting;
            if (request.Id.HasValue)
            {
                var entity = await _context.MarketingDefaultSettings.FindAsync(request.Id);
                Guard.Against.Null(entity, request.Id);
                marketingDefaultSetting = entity;
            }
            else
            {
                marketingDefaultSetting = new Domain.Entities.MarketingDefaultSetting();
                await _context.MarketingDefaultSettings.AddAsync(marketingDefaultSetting);
                marketingDefaultSetting.CompanyId = _currentUserService.CompanyId;
            }
            marketingDefaultSetting.BranchId = request.BranchId;
            marketingDefaultSetting.CurrencyId = request.CurrencyId;
            marketingDefaultSetting.CustomerTypeId = request.CustomerTypeId;
            marketingDefaultSetting.SalesTypeId = request.SalesTypeId;
            await _context.SaveChangesAsync(cancellationToken);
            return marketingDefaultSetting.Id;
        }
    }
}
