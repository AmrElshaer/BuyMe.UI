using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Product.Commonds.DeleteProduct
{
    public class DeleteProductCommond : IRequest<Unit>
    {
        public int ProductId { get; set; }

        public class DeleteProductCommondHandler : IRequestHandler<DeleteProductCommond, Unit>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IFileService _fileService;

            public DeleteProductCommondHandler(IBuyMeDbContext context, IFileService fileService)
            {
                this._context = context;
                _fileService = fileService;
            }

            public async Task<Unit> Handle(DeleteProductCommond request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Include(a => a.ProductImages).FirstOrDefaultAsync(a => a.ProductId == request.ProductId);
                _ = product ?? throw new NotFoundException(nameof(Domain.Entities.Product), request.ProductId);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync(cancellationToken);
                product.ProductImages.ToList().ForEach(a => _fileService.DeleteFile("images", a.Image));
                return Unit.Value;
            }
        }
    }
}