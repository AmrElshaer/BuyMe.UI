using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Currency.Queries
{
    public class GetCurrenciesQuery:IRequest<QueryResult<CurrencyDto>>
    {
        public DataManager DM { get; set; }
        public GetCurrenciesQuery()
        {
            DM ??= new DataManager();
        }
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
                if (!string.IsNullOrEmpty(request.DM.SearchValue)) 
                { 
                    dataSource = dataSource.Where(a => a.CurrencyName.Contains(request.DM.SearchValue)||
                    a.CurrencyCode.Contains(request.DM.SearchValue));
                }
                if (request.DM.Skip!=null&&request.DM.Skip != 0) dataSource = dataSource.Skip(request.DM.Skip.Value);
                if (request.DM.Take != null && request.DM.Take != 0) dataSource = dataSource.Take(request.DM.Take.Value);
                int count = dataSource.Count();
                var currencies = dataSource.OrderByDescending(a => a.CurrencyId).Select(_mapper.Map<CurrencyDto>).ToList();
                return new QueryResult<CurrencyDto>() { count = count, result = currencies };
            }

        }
    }
}
