using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.CartItem.Commonds
{
    public class DeleteCartItemCommond:IRequest<Unit>
    {
        public int CartItemId { get;private set; }

        public DeleteCartItemCommond(int cartItemId)
        {
            CartItemId = cartItemId;
        }
        public class DeleteCartItemCommondHandler : IRequestHandler<DeleteCartItemCommond, Unit>
        {
            private readonly IBuyMeDbContext dbContext;

            public DeleteCartItemCommondHandler(IBuyMeDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<Unit> Handle(DeleteCartItemCommond request, CancellationToken cancellationToken)
            {
                var cartItem = await dbContext.CartItems.FindAsync(request.CartItemId);
                if (cartItem is null)
                {
                    throw new NotFoundException("CartItem",request.CartItemId);
                }
                dbContext.CartItems.Remove(cartItem);
                await dbContext.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
