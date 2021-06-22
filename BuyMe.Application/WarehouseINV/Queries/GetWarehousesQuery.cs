using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.WarehouseINV.Queries
{
    public class GetWarehousesQuery:IRequest<QueryResult<WarhouseDto>>
    {
        public DataManagerRequest DM { get; set; }
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
                var operation = new DataOperations();
                if (request.DM.Search != null && request.DM.Search.Count > 0) dataSource = operation.PerformSearching(dataSource, request.DM.Search);
                if (request.DM.Skip != 0) dataSource = operation.PerformSkip(dataSource, request.DM.Skip);
                if (request.DM.Take != 0) dataSource = operation.PerformTake(dataSource, request.DM.Take);
                int count = dataSource.Count();
                var warhouses = dataSource.OrderByDescending(a => a.WarehouseId).Select(_mapper.Map<WarhouseDto>).ToList();
                return new QueryResult<WarhouseDto>() { count = count, result = warhouses };
            }

        }
    }
}
