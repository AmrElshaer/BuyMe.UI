using System.Collections.Generic;
using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.ShipmentType.Queries
{
    public class GetShipmentTypeQuery :BaseRequestQuery, IRequest<QueryResult<ShipmentTypeDto>>
    {
        public class GetShipmentTypeQueryHandler : IRequestHandler<GetShipmentTypeQuery, QueryResult<ShipmentTypeDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetShipmentTypeQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QueryResult<ShipmentTypeDto>> Handle(GetShipmentTypeQuery request, CancellationToken cancellationToken)
            {
                var res =await _context.ShipmentTypes
                    .ApplyFiliter(request, a => a.ShipmentTypeName.Contains(request.DM.SearchValue))
                    .ApplySkip(request).ApplyTake(request).Build(a => a.Id);
                return new QueryResult<ShipmentTypeDto>() { count = res.Count, result =_mapper.Map<IList<ShipmentTypeDto>>(res.Data)  };
            }
        }
    }
}