using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace BuyMe.Application.SalesOrder.Queries
{
    public  class GetSalesOrdersQuery:IRequest<QueryResult<SalesOrderDto>>
    {
        public DataManager  DM { get; set; }
        public GetSalesOrdersQuery()
        {
            DM ??= new DataManager();
        }
        public class GetSalesOrderQueryHandler : IRequestHandler<GetSalesOrdersQuery, QueryResult<SalesOrderDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService currentUserService;

            public GetSalesOrderQueryHandler(IBuyMeDbContext context,IMapper mapper,ICurrentUserService currentUserService)
            {
                _context = context;
                _mapper = mapper;
                this.currentUserService = currentUserService;
            }
            public async Task<QueryResult<SalesOrderDto>> Handle(GetSalesOrdersQuery request, CancellationToken cancellationToken)
            {
                var dataSource = _context.SalesOrders.Include(a=>a.Branch).Include(a=>a.Customer).Include(a=>a.Currency)
                    .Include(a=>a.SalesType).Where(a=>a.CompanyId==currentUserService.CompanyId).AsQueryable();
                if (!string.IsNullOrEmpty(request.DM.SearchValue))
                { 
                    dataSource = dataSource.Where(a=>
                    a.SalesOrderName.Contains( request.DM.SearchValue)
                    );
                } 
                if (request.DM.Skip!=null&&request.DM.Skip != 0)dataSource = dataSource.Skip(request.DM.Skip.Value);
                if (request.DM.Take != null && request.DM.Take != 0)dataSource = dataSource.Take(request.DM.Take.Value);
                int count = dataSource.Count();
                var products = dataSource.OrderByDescending(a => a.SalesOrderId).Select(_mapper.Map<SalesOrderDto>).ToList();
                return new QueryResult<SalesOrderDto>() { count=count,result= products };
            }
            
        }
    }
}
