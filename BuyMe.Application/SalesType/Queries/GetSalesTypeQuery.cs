using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.SalesType.Queries
{
    public class GetSalesTypeQuery : IRequest<QueryResult<SalesTypeDto>>
    {
        public DataManager DM { get; set; }

        public GetSalesTypeQuery()
        {
            DM ??= new DataManager();
        }

        public class GetSalesTypeQueryHandler : IRequestHandler<GetSalesTypeQuery, QueryResult<SalesTypeDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService currentUserService;

            public GetSalesTypeQueryHandler(IBuyMeDbContext context, IMapper mapper, ICurrentUserService currentUserService)
            {
                _context = context;
                _mapper = mapper;
                this.currentUserService = currentUserService;
            }

            public async Task<QueryResult<SalesTypeDto>> Handle(GetSalesTypeQuery request, CancellationToken cancellationToken)
            {
                var dataSource = _context.SalesTypes.Where(a => a.CompanyId == currentUserService.CompanyId).AsQueryable();
                if (!string.IsNullOrEmpty(request.DM.SearchValue)) dataSource = dataSource.Where(a => a.SalesTypeName.Contains(request.DM.SearchValue));
                if (request.DM.Skip != null && request.DM.Skip != 0) dataSource = dataSource.Skip(request.DM.Skip.Value);
                if (request.DM.Take != null && request.DM.Take != 0) dataSource = dataSource.Take(request.DM.Take.Value);
                int count = dataSource.Count();
                var warhouses = dataSource.OrderByDescending(a => a.Id).Select(_mapper.Map<SalesTypeDto>).ToList();
                return new QueryResult<SalesTypeDto>() { count = count, result = warhouses };
            }
        }
    }
}