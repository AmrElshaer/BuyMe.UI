using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Product.Commonds.DeleteProduct
{
    public class DeleteProductCommond:IRequest<Unit>
    {
        public int ProductId  { get; set; }
        public class DeleteProductCommondHandler : IRequestHandler<DeleteProductCommond, Unit>
        {
            private readonly IBuyMeDbContext _context;

            public DeleteProductCommondHandler(IBuyMeDbContext context)
            {
                this._context = context;
            }
            public async Task<Unit> Handle(DeleteProductCommond request, CancellationToken cancellationToken)
            {
                var product =await _context.Products.FindAsync(request.ProductId);
                _ = product ?? throw new NotFoundException(nameof(Domain.Entities.Product), request.ProductId);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            } 
        }
    }
}
