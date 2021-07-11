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

namespace BuyMe.Application.Product.Queries
{
    public  class GetProductQuery:IRequest<QueryResult<ProductDto>>
    {
        public DataManager  DM { get; set; }
        public GetProductQuery()
        {
            DM ??= new DataManager();
        }
        public class GetProductQueryHandler : IRequestHandler<GetProductQuery, QueryResult<ProductDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService currentUserService;

            public GetProductQueryHandler(IBuyMeDbContext context,IMapper mapper,ICurrentUserService currentUserService)
            {
                _context = context;
                _mapper = mapper;
                this.currentUserService = currentUserService;
            }
            public async Task<QueryResult<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
            {
                var dataSource = _context.Products.Include(a=>a.Branch)
                    .Include(a=>a.UnitOfMeasure).Include(a=>a.Currency).Where(a=>a.CompanyId==currentUserService.CompanyId).AsQueryable();
                if (!string.IsNullOrEmpty(request.DM.SearchValue))
                { 
                    dataSource = dataSource.Where(a=>
                    a.ProductName.Contains( request.DM.SearchValue)||
                    a.Barcode.Contains(request.DM.SearchValue) 
                    );
                } 
                if (request.DM.Skip!=null&&request.DM.Skip != 0)dataSource = dataSource.Skip(request.DM.Skip.Value);
                if (request.DM.Take != null && request.DM.Take != 0)dataSource = dataSource.Take(request.DM.Take.Value);
                int count = dataSource.Count();
                var products = dataSource.OrderByDescending(a => a.ProductId).Select(_mapper.Map<ProductDto>).ToList();
                return new QueryResult<ProductDto>() { count=count,result= products };
            }
            
        }
    }
}
