using System.Collections.Generic;
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
    public class GetWarehousesQuery :BaseRequestQuery, IRequest<QueryResult<WarhouseDto>>
    {
       

        public class GetWarehousesQueryHandler : IRequestHandler<GetWarehousesQuery, QueryResult<WarhouseDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;
            public GetWarehousesQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QueryResult<WarhouseDto>> Handle(GetWarehousesQuery request, CancellationToken cancellationToken)
            {
                var res =await _context.Warehouses.Include(a => a.Branch)
                    .ApplyFiliter(request,a => a.WarehouseName.Contains(request.DM.SearchValue))
                    .ApplySkip(request).ApplyTake(request).Build(a => a.WarehouseId);
                return new QueryResult<WarhouseDto>() { count = res.Count, result =_mapper.Map<IList<WarhouseDto>>(res.Data)  };
            }
        }
    }
}