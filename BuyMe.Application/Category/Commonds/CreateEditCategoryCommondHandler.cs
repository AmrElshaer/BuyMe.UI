
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Category.Commonds
{
    public class CreateEditCategoryCommondHandler : IRequestHandler<CreateEditCategoryCommond, int>
    {
        private readonly IBuyMeDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public CreateEditCategoryCommondHandler(IBuyMeDbContext context,ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }
        public async Task<int> Handle(CreateEditCategoryCommond request, CancellationToken cancellationToken)
        {
            Domain.Entities.Category category;
            if (request.CategoryId.HasValue)
            {
                var entity = await _context.Categories.FindAsync(request.CategoryId);
                if (entity == null)
                    throw new NotFoundException("Category", request.CategoryId);
                category = entity;
            }
            else
            {
                category = new Domain.Entities.Category();
                await _context.Categories.AddAsync(category);
                category.CompanyId = _currentUserService.CompanyId;
            }
            category.CategoryName = request.CategoryName;
            category.Description = request.Description;
            await _context.SaveChangesAsync(cancellationToken);
            return category.CategoryId.Value;
        }
    }
}
