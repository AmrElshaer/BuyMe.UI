using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace BuyMe.Application.UnitOfMeasure.Queries
{
    public  class GetUOMQuery:IRequest<QueryResult<UnitOfMeasureDto>>
    {
        public DataManager  DM { get; set; }
        public GetUOMQuery()
        {
            DM ??= new DataManager();
        }
        public class GetUOMsQueryHandler : IRequestHandler<GetUOMQuery, QueryResult<UnitOfMeasureDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService currentUserService;

            public GetUOMsQueryHandler(IBuyMeDbContext context,IMapper mapper,ICurrentUserService currentUserService)
            {
                _context = context;
                _mapper = mapper;
                this.currentUserService = currentUserService;
            }
            public async Task<QueryResult<UnitOfMeasureDto>> Handle(GetUOMQuery request, CancellationToken cancellationToken)
            {
                var dataSource = _context.UnitOfMeasures.Where(a=>a.CompanyId==currentUserService.CompanyId).AsQueryable();

                if (!string.IsNullOrEmpty(request.DM.SearchValue))
                { 
                    dataSource = dataSource.Where(a=>a.UOM.Contains( request.DM.SearchValue));
                }
                if (request.DM.Skip !=null&& request.DM.Skip != 0)dataSource = dataSource.Skip(request.DM.Skip.Value);
                if (request.DM.Take !=null&& request.DM.Take != 0)dataSource = dataSource.Take(request.DM.Take.Value);
                int count = dataSource.Count();
                var ums = dataSource.OrderByDescending(a => a.Id).Select(_mapper.Map<UnitOfMeasureDto>).ToList();
                return new QueryResult<UnitOfMeasureDto>() { count=count,result= ums };
            }
            
        }
    }
}
