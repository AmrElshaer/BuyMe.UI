using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Category.Commonds.DeleteCategory
{
    public class DeleteCategoryCommond : IRequest<Unit>
    {
        public int CategoryId { get; set; }

        public class DeleteCategoryCommondHandler : IRequestHandler<DeleteCategoryCommond, Unit>
        {
            private readonly IBuyMeDbContext _context;

            public DeleteCategoryCommondHandler(IBuyMeDbContext context)
            {
                this._context = context;
            }

            public async Task<Unit> Handle(DeleteCategoryCommond request, CancellationToken cancellationToken)
            {
                var category = await _context.Categories.FindAsync(request.CategoryId);
                _ = category ?? throw new NotFoundException(nameof(Domain.Entities.Company), request.CategoryId);
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}