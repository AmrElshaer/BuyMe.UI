using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.CartItem.Commonds
{
    public class CreateEditCartItemCommond : IRequest<int>
    {
        public int? Id { get; set; }
        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public int QTN { get; set; }
        public class CreateEditCartItemCommondHandler : IRequestHandler<CreateEditCartItemCommond, int>
        {
            private readonly IBuyMeDbContext _context;
            private readonly ICurrentUserService _currUser;

            public CreateEditCartItemCommondHandler(IBuyMeDbContext context, ICurrentUserService currentUserService)
            {
                _context = context;
                _currUser = currentUserService;
            }
            public async Task<int> Handle(CreateEditCartItemCommond request, CancellationToken cancellationToken)
            {
                Domain.Entities.CartItem cartItem;
                if (request.Id.HasValue)
                {
                    var entity = await _context.CartItems.FindAsync(request.Id);
                    cartItem= Guard.Against.Null(entity, "CartItem");
                    cartItem.SetQTN(request.QTN);
                }
                else
                {
                    cartItem = new Domain.Entities.CartItem(request.ProductId,request.QTN,_currUser.CompanyId,request.CustomerId);
                    await _context.CartItems.AddAsync(cartItem);
                }
                await _context.SaveChangesAsync(cancellationToken);
                return cartItem.Id;
            }
        }
    }
}