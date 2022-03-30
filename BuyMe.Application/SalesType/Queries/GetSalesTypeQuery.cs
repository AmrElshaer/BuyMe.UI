using System.Collections.Generic;
using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuyMe.Application.Common.Models;
namespace BuyMe.Application.SalesType.Queries
{
    public class GetSalesTypeQuery : BaseRequestQuery,IRequest<QueryResult<SalesTypeDto>>
    {

        public class GetSalesTypeQueryHandler : IRequestHandler<GetSalesTypeQuery, QueryResult<SalesTypeDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;
            public GetSalesTypeQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QueryResult<SalesTypeDto>> Handle(GetSalesTypeQuery request, CancellationToken cancellationToken)
            {
                var res =await _context.SalesTypes
                        .ApplyFiliter(request,a => a.SalesTypeName.Contains(request.DM.SearchValue))
                        .ApplySkip(request).ApplyTake(request).Build(a => a.Id);
                return new QueryResult<SalesTypeDto>() { count = res.Count, result = _mapper.Map<IList<SalesTypeDto>>(res.Data) };
            }
        }
    }
}