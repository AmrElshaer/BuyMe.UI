using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.MarketingDefaultSetting.Queries
{
    public class GetDefaultMarkSettingQuery:IRequest<MarketingDefaultSettingDto>
    {
        public class GetDefaultMarkSettingQueryHandler : IRequestHandler<GetDefaultMarkSettingQuery, MarketingDefaultSettingDto>
        {
            private readonly IBuyMeDbContext _context;
            private readonly ICurrentUserService _currentUserService;
            private readonly IMapper _mapper;

            public GetDefaultMarkSettingQueryHandler(IMapper mapper,IBuyMeDbContext context, ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUserService = currentUserService;
                _mapper = mapper;
            }
            public async Task<MarketingDefaultSettingDto> Handle(GetDefaultMarkSettingQuery request, CancellationToken cancellationToken)
            {
                var marketingSetting=await _context.MarketingDefaultSettings.Include(a=>a.Currency).FirstOrDefaultAsync(a=>a.CompanyId==_currentUserService.CompanyId);
                return _mapper.Map<MarketingDefaultSettingDto>(marketingSetting);
            }
        }
    }
}
