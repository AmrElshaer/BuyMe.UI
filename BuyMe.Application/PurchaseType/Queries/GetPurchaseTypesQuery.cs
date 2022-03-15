using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.PurchaseType.Queries
{
    public class GetPurchaseTypesQuery: BaseRequestQuery, IRequest<QueryResult<PurchaseTypeDto>>
    {
        public class GetPurchaseTypesQueryHandler : IRequestHandler<GetPurchaseTypesQuery, QueryResult<PurchaseTypeDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetPurchaseTypesQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QueryResult<PurchaseTypeDto>> Handle(GetPurchaseTypesQuery request, CancellationToken cancellationToken)
            {
                var dataSource = _context.PurchaseTypes
                    .ApplyFiliter(request, a => a.Name.Contains(request.DM.SearchValue))
                    .ApplySkip(request)
                    .ApplyTake(request);
                var count = dataSource.Count();
                var vendorTypes = await dataSource.OrderByDescending(a => a.Id).ToListAsync();
                return new QueryResult<PurchaseTypeDto>() { count = count, result = _mapper.Map<IList<PurchaseTypeDto>>(vendorTypes) };
            }
        }
    }
}
