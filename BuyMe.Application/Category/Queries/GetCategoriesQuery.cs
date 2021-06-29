using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Category.Queries
{
    public class GetCategoriesQuery : IRequest<QueryResult<CategoryDto>>
    {
        public DataManager DM { get; set; }
        public GetCategoriesQuery()
        {
            DM ??= new DataManager();
        }

        public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, QueryResult<CategoryDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService currentUserService;

            public GetCategoriesQueryHandler(IBuyMeDbContext context, IMapper mapper, ICurrentUserService currentUserService)
            {
                _context = context;
                _mapper = mapper;
                this.currentUserService = currentUserService;
            }

            public async Task<QueryResult<CategoryDto>> Handle(GetCategoriesQuery req, CancellationToken cancellationToken)
            {
                var dataSource = _context.Categories.Where(a => a.CompanyId == currentUserService.CompanyId).AsQueryable();
                if (!string.IsNullOrEmpty(req.DM.SearchValue)) dataSource = dataSource.Where(a => a.CategoryName.Contains(req.DM.SearchValue));
                if (req.DM.Skip != null&&req.DM.Skip!=0) dataSource = dataSource.Skip(req.DM.Skip.Value);
                if (req.DM.Take != null && req.DM.Take != 0) dataSource = dataSource.Take(req.DM.Take.Value);
                int count = dataSource.Count();
                var categories = dataSource.OrderByDescending(a => a.CategoryId).Select(_mapper.Map<CategoryDto>).ToList();
                return new QueryResult<CategoryDto>() { count = count, result = categories };
            }
        }
    }
}