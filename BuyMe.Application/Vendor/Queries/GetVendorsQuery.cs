using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using BuyMe.Application.VendorType.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Vendor.Queries
{
    public class GetVendorsQuery:BaseRequestQuery, IRequest<QueryResult<VendorDto>>
    {
        public class GetVendorsQueryHandler : IRequestHandler<GetVendorsQuery, QueryResult<VendorDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetVendorsQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QueryResult<VendorDto>> Handle(GetVendorsQuery request, CancellationToken cancellationToken)
            {
                var dataSource = _context.Vendors.ApplyFiliter(request, a => a.Name.Contains(request.DM.SearchValue))
                    .ApplySkip(request).ApplyTake(request);
                var count = dataSource.Count();
                var vendorTypes = await dataSource.OrderByDescending(a => a.Id).ToListAsync();
                return new QueryResult<VendorDto>() { count = count, result = _mapper.Map<IList<VendorDto>>(vendorTypes) };
            }
        }
    }
  
}
