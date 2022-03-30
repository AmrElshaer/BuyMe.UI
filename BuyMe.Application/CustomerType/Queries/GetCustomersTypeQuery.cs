using System.Collections.Generic;
using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.CustomerType.Queries
{
    public class GetCustomersTypeQuery : BaseRequestQuery,IRequest<QueryResult<CustomerTypeDto>>
    {
        public class GetCustomersTypeQueryHandler : IRequestHandler<GetCustomersTypeQuery, QueryResult<CustomerTypeDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetCustomersTypeQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QueryResult<CustomerTypeDto>> Handle(GetCustomersTypeQuery request, CancellationToken cancellationToken)
            {
                var res =await _context.CustomerTypes.ApplyFiliter(request,a => a.CustomerTypeName.Contains(request.DM.SearchValue))
                    .ApplySkip(request).ApplyTake(request).Build(a => a.Id);
                return new QueryResult<CustomerTypeDto>() { count = res.Count, result =_mapper.Map<IList<CustomerTypeDto> >(
                    res.Data) };
            }
        }
    }
}