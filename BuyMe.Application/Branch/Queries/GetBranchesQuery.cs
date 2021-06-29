using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Branch.Queries
{
    public class GetBranchesQuery:IRequest<QueryResult<BranchDto>>
    {
        public DataManager DM { get; set; }
        public GetBranchesQuery()
        {
            DM ??= new DataManager();
        }
        public class GetBranchesQueryHandler : IRequestHandler<GetBranchesQuery, QueryResult<BranchDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService _currentUserService;

            public GetBranchesQueryHandler(IBuyMeDbContext context, IMapper mapper, ICurrentUserService currentUserService)
            {
                _context = context;
                _mapper = mapper;
                _currentUserService = currentUserService;
            }
            public async Task<QueryResult<BranchDto>> Handle(GetBranchesQuery req, CancellationToken cancellationToken)
            {
                var dataSource = _context.Branches.Include(a=>a.Currency).Where(a => a.CompanyId == _currentUserService.CompanyId)
                    .AsQueryable();
                if (!string.IsNullOrEmpty(req.DM.SearchValue))
                {
                    dataSource = dataSource.Where(a => a.BranchName.Contains(req.DM.SearchValue) ||
                    a.Address.Contains(req.DM.SearchValue) || a.City.Contains(req.DM.SearchValue)||
                    a.Currency.CurrencyName.Contains(req.DM.SearchValue));
                }
                if (req.DM.Skip !=null&& req.DM.Skip != 0) dataSource =dataSource.Skip(req.DM.Skip.Value);
                if (req.DM.Take != null && req.DM.Take != 0) dataSource = dataSource.Take(req.DM.Take.Value);
                int count = dataSource.Count();
                var currencies = dataSource.OrderByDescending(a => a.CurrencyId).Select(_mapper.Map<BranchDto>).ToList();
                return new QueryResult<BranchDto>() { count = count, result = currencies };
            }

        }
    }
}
