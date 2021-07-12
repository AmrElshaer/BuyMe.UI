using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.CustomerType.Queries
{
    public class GetCustomersTypeQuery : IRequest<QueryResult<CustomerTypeDto>>
    {
        public DataManager DM { get; set; }

        public GetCustomersTypeQuery()
        {
            DM ??= new DataManager();
        }

        public class GetCustomersTypeQueryHandler : IRequestHandler<GetCustomersTypeQuery, QueryResult<CustomerTypeDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService currentUserService;

            public GetCustomersTypeQueryHandler(IBuyMeDbContext context, IMapper mapper, ICurrentUserService currentUserService)
            {
                _context = context;
                _mapper = mapper;
                this.currentUserService = currentUserService;
            }

            public async Task<QueryResult<CustomerTypeDto>> Handle(GetCustomersTypeQuery request, CancellationToken cancellationToken)
            {
                var dataSource = _context.CustomerTypes.Where(a => a.CompanyId == currentUserService.CompanyId).AsQueryable();
                if (!string.IsNullOrEmpty(request.DM.SearchValue)) dataSource = dataSource.Where(a => a.CustomerTypeName.Contains(request.DM.SearchValue));
                if (request.DM.Skip != null && request.DM.Skip != 0) dataSource = dataSource.Skip(request.DM.Skip.Value);
                if (request.DM.Take != null && request.DM.Take != 0) dataSource = dataSource.Take(request.DM.Take.Value);
                int count = dataSource.Count();
                var warhouses = dataSource.OrderByDescending(a => a.Id).Select(_mapper.Map<CustomerTypeDto>).ToList();
                return new QueryResult<CustomerTypeDto>() { count = count, result = warhouses };
            }
        }
    }
}