using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Syncfusion.EJ2.Base;
using System;
using System.Collections;
using System.Collections.Generic;
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
        public DataManagerRequest  DM { get; set; }
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
                var dataSource = _context.Products.Include(a=>a.Branch).Include(a=>a.UnitOfMeasure).Include(a=>a.Currency)
                    .Where(a=>a.CompanyId==currentUserService.CompanyId).AsQueryable();
                var operation = new DataOperations();
                if(request.DM.Search != null && request.DM.Search.Count > 0) dataSource = operation.PerformSearching(dataSource, request.DM.Search); 
                if (request.DM.Skip != 0)dataSource = operation.PerformSkip(dataSource, request.DM.Skip);
                if (request.DM.Take != 0)dataSource = operation.PerformTake(dataSource, request.DM.Take);
                int count = dataSource.Count();
                var products = dataSource.OrderByDescending(a => a.ProductId).Select(_mapper.Map<ProductDto>).ToList();
                return new QueryResult<ProductDto>() { count=count,result= products };
            }
            
        }
    }
}
