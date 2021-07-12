using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Product.Queries
{
    public class GetProductImagesQuery : IRequest<IList<ProductImageDto>>
    {
        public GetProductImagesQuery(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; private set; }

        public class GetProductImagesQueryHandler : IRequestHandler<GetProductImagesQuery, IList<ProductImageDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetProductImagesQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IList<ProductImageDto>> Handle(GetProductImagesQuery request, CancellationToken cancellationToken)
            {
                var productsImages = await _context.ProductImages.Where(a => a.ProductId == request.ProductId).ToListAsync();
                return _mapper.Map<IList<ProductImageDto>>(productsImages);
            }
        }
    }
}