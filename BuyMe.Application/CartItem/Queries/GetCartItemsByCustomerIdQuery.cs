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

namespace BuyMe.Application.CartItem.Queries
{
    public class GetCartItemsByCustomerIdQuery:IRequest<IList<CartItemDto>>
    {
        public GetCartItemsByCustomerIdQuery(int customerId)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get;private set; }
        public class GetCartItemsByCustomerIdQueryHandler : IRequestHandler<GetCartItemsByCustomerIdQuery, IList<CartItemDto>>
        {
            private readonly IBuyMeDbContext _dbContext;
            private readonly IMapper mapper;

            public GetCartItemsByCustomerIdQueryHandler(IBuyMeDbContext dbContext,IMapper mapper)
            {
                this._dbContext = dbContext;
                this.mapper = mapper;
            }
            public async Task<IList<CartItemDto>> Handle(GetCartItemsByCustomerIdQuery request, CancellationToken cancellationToken)
            {
                var cartItems = await _dbContext.CartItems.Include(a => a.Product).ThenInclude(a => a.ProductImages)
                     .Include(a => a.Product).ThenInclude(a=>a.UnitOfMeasure)
                     .Include(a=>a.Product).ThenInclude(a=>a.Currency)
                    .Where(a => a.CustomerId == request.CustomerId).ToListAsync();
                return this.mapper.Map<IList<CartItemDto>>(cartItems);
            }
        }
    }
}
