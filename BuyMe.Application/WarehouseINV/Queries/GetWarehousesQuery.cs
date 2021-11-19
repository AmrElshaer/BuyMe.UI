using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.WarehouseINV.Queries
{
    public class GetWarehousesQuery : IRequest<QueryResult<WarhouseDto>>
    {
        public DataManager DM { get; set; }

        public GetWarehousesQuery()
        {
            DM ??= new DataManager();
        }

        public class GetWarehousesQueryHandler : IRequestHandler<GetWarehousesQuery, QueryResult<WarhouseDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService currentUserService;

            public GetWarehousesQueryHandler(IBuyMeDbContext context, IMapper mapper, ICurrentUserService currentUserService)
            {
                _context = context;
                _mapper = mapper;
                this.currentUserService = currentUserService;
            }

            public async Task<QueryResult<WarhouseDto>> Handle(GetWarehousesQuery request, CancellationToken cancellationToken)
            {
                var dataSource = _context.Warehouses.Include(a => a.Branch).Where(a => a.CompanyId == currentUserService.CompanyId).AsQueryable();
                if (!string.IsNullOrEmpty(request.DM.SearchValue)) dataSource = dataSource.Where(a => a.WarehouseName.Contains(request.DM.SearchValue));
                if (request.DM.Skip != null && request.DM.Skip != 0) dataSource = dataSource.Skip(request.DM.Skip.Value);
                if (request.DM.Take != 0&&request.DM.Take!=null) dataSource = dataSource.Take(request.DM.Take.Value);
                int count = dataSource.Count();
                var warhouses = dataSource.OrderByDescending(a => a.WarehouseId).Select(_mapper.Map<WarhouseDto>).ToList();
                return new QueryResult<WarhouseDto>() { count = count, result = warhouses };
            }
        }
    }
}