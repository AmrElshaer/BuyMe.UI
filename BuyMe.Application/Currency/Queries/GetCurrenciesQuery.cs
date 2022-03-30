using System;
using System.Collections.Generic;
using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Currency.Queries
{
    public class GetCurrenciesQuery :BaseRequestQuery ,IRequest<QueryResult<CurrencyDto>>
    {
       

        public class GetCurrenciesQueryHandler : IRequestHandler<GetCurrenciesQuery, QueryResult<CurrencyDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetCurrenciesQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QueryResult<CurrencyDto>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
            {
                Expression<Func<Domain.Entities.Currency, bool>> expression = a => a.CurrencyName.Contains(request.DM.SearchValue) ||
                                                                                   a.CurrencyCode.Contains(request.DM.SearchValue);
                var res =await _context.Currencies.ApplyFiliter(request, expression)
                    .ApplySkip(request).ApplyTake(request).Build(a => a.CurrencyId);
                return new QueryResult<CurrencyDto>() { count = res.Count, result =_mapper.Map<IList<CurrencyDto>>(res.Data) };
            }
        }
    }
}