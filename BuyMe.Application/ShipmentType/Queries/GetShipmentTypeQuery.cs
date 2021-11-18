using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.ShipmentType.Queries
{
    public class GetShipmentTypeQuery : IRequest<QueryResult<ShipmentTypeDto>>
    {
        public DataManager DM { get; set; }

        public GetShipmentTypeQuery()
        {
            DM ??= new DataManager();
        }

        public class GetShipmentTypeQueryHandler : IRequestHandler<GetShipmentTypeQuery, QueryResult<ShipmentTypeDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService currentUserService;

            public GetShipmentTypeQueryHandler(IBuyMeDbContext context, IMapper mapper, ICurrentUserService currentUserService)
            {
                _context = context;
                _mapper = mapper;
                this.currentUserService = currentUserService;
            }

            public async Task<QueryResult<ShipmentTypeDto>> Handle(GetShipmentTypeQuery request, CancellationToken cancellationToken)
            {
                var dataSource = _context.ShipmentTypes.Where(a => a.CompanyId == currentUserService.CompanyId).AsQueryable();
                if (!string.IsNullOrEmpty(request.DM.SearchValue)) dataSource = dataSource.Where(a => a.ShipmentTypeName.Contains(request.DM.SearchValue));
                if (request.DM.Skip != null && request.DM.Skip != 0) dataSource = dataSource.Skip(request.DM.Skip.Value);
                if (request.DM.Take != null && request.DM.Take != 0) dataSource = dataSource.Take(request.DM.Take.Value);
                int count = dataSource.Count();
                var shipmentTypes = dataSource.OrderByDescending(a => a.Id).Select(_mapper.Map<ShipmentTypeDto>).ToList();
                return new QueryResult<ShipmentTypeDto>() { count = count, result = shipmentTypes };
            }
        }
    }
}