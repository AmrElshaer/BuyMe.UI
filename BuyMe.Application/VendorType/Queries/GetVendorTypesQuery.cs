using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.VendorType.Queries
{
    public class GetVendorTypesQuery: BaseRequestQuery, IRequest<QueryResult<VendorTypeDto>>
    {
        public class GetVendorTypesQueryHandler : IRequestHandler<GetVendorTypesQuery, QueryResult<VendorTypeDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetVendorTypesQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QueryResult<VendorTypeDto>> Handle(GetVendorTypesQuery request, CancellationToken cancellationToken)
            {
                var dataSource = _context.VendorTypes
                    .ApplyFiliter(request, a => a.Name.Contains(request.DM.SearchValue))
                    .ApplySkip(request)
                    .ApplyTake(request);
                var count = dataSource.Count();
                var vendorTypes = await dataSource.OrderByDescending(a => a.Id).ToListAsync();
                return new QueryResult<VendorTypeDto>() { count = count, result = _mapper.Map<IList<VendorTypeDto>>(vendorTypes) };
            }
        }
    }
}