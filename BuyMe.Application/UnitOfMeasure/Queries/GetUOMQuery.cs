using System.Collections.Generic;
using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.UnitOfMeasure.Queries
{
    public class GetUOMQuery : BaseRequestQuery,IRequest<QueryResult<UnitOfMeasureDto>>
    {
       

        public class GetUOMsQueryHandler : IRequestHandler<GetUOMQuery, QueryResult<UnitOfMeasureDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetUOMsQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QueryResult<UnitOfMeasureDto>> Handle(GetUOMQuery request, CancellationToken cancellationToken)
            {
                var res =await _context.UnitOfMeasures
                    .ApplyFiliter(request, a => a.UOM.Contains(request.DM.SearchValue))
                    .ApplySkip(request).ApplyTake(request).Build(a => a.Id);
                
                return new QueryResult<UnitOfMeasureDto>() { count = res.Count
                    , result =_mapper.Map<IList<UnitOfMeasureDto>>(res.Data)  };
            }
        }
    }
}