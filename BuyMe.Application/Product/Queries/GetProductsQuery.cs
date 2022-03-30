using System;
using System.Collections.Generic;
using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Product.Queries
{
    public class GetProductQuery : BaseRequestQuery,IRequest<QueryResult<ProductDto>>
    {
        public class GetProductQueryHandler : IRequestHandler<GetProductQuery, QueryResult<ProductDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetProductQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QueryResult<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
            {
                var res =await _context.Products.Include(a => a.Branch)
                    .Include(a => a.UnitOfMeasure).Include(a => a.Currency)
                    .ApplyFiliter(request, SearchQuery(request)
                    ).ApplySkip(request).ApplyTake(request).Build(a => a.ProductId);
                
                return new QueryResult<ProductDto>() { count = res.Count, result =_mapper.Map<IList<ProductDto>>(res.Data)  };
            }

            private static Expression<Func<Domain.Entities.Product, bool>> SearchQuery(GetProductQuery request)
            {
                return a =>
                    a.ProductName.Contains(request.DM.SearchValue) ||
                    a.Barcode.Contains(request.DM.SearchValue);
            }
        }
    }
}