using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Currency.Queries
{
    public class GetCurrenciesQuery:IRequest<QueryResult<CurrencyDto>>
    {
        public DataManagerRequest DM { get; set; }
        public class GetCurrenciesQueryHandler : IRequestHandler<GetCurrenciesQuery, QueryResult<CurrencyDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService _currentUserService;

            public GetCurrenciesQueryHandler(IBuyMeDbContext context, IMapper mapper,ICurrentUserService currentUserService)
            {
                _context = context;
                _mapper = mapper;
                _currentUserService = currentUserService;
            }
            public async Task<QueryResult<CurrencyDto>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
            {
                var dataSource = _context.Currencies.Where(a=>a.CompanyId== _currentUserService.CompanyId)
                    .AsQueryable();
                var operation = new DataOperations();
                if (request.DM.Search != null && request.DM.Search.Count > 0) dataSource = operation.PerformSearching(dataSource, request.DM.Search);
                if (request.DM.Skip != 0) dataSource = operation.PerformSkip(dataSource, request.DM.Skip);
                if (request.DM.Take != 0) dataSource = operation.PerformTake(dataSource, request.DM.Take);
                int count = dataSource.Count();
                var currencies = dataSource.OrderByDescending(a => a.CurrencyId).Select(_mapper.Map<CurrencyDto>).ToList();
                return new QueryResult<CurrencyDto>() { count = count, result = currencies };
            }

        }
    }
}
