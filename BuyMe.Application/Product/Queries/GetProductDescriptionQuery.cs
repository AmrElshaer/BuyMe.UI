using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Product.Queries
{
    public class GetProductDescriptionQuery: IRequest<IList<ProductDescriptionDto>>
    {
        public int? ProductId { get;private set; }
        public int CategoryId { get; private set; }

        public GetProductDescriptionQuery(int? productId, int categoryId)
        {
            ProductId = productId;
            CategoryId = categoryId;
        }
        public class GetProductDescriptionQueryHandler :
            IRequestHandler<GetProductDescriptionQuery, IList<ProductDescriptionDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetProductDescriptionQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<IList<ProductDescriptionDto>> Handle(GetProductDescriptionQuery request, CancellationToken cancellationToken)
            {
                var productDescriptions = await _context.ProductDescriptions.Include(a=>a.CategoryDescription).Where(a => a.ProductId == request.ProductId&&a.CategoryDescription.CategoryId==request.CategoryId).ToListAsync();
                return _mapper.Map<IList<ProductDescriptionDto>>(productDescriptions);
            }
        }
    }
}
