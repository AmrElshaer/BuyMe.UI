using AutoMapper;
using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Product.Queries
{
    public class GetProducbyIdtQuery : IRequest<ProductDto>
    {
        public GetProducbyIdtQuery(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; private set; }

        public class GetProducbyIdtQueryHandler : IRequestHandler<GetProducbyIdtQuery, ProductDto>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetProducbyIdtQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductDto> Handle(GetProducbyIdtQuery request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FirstOrDefaultAsync(a => a.ProductId == request.ProductId);
                Guard.Against.Null(product, request.ProductId);
                return _mapper.Map<ProductDto>(product);
            }
        }
    }
}