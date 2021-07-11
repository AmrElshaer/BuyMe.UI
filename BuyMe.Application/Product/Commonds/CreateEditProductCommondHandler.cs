
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Product.Commonds.CreatEditProductImages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Product.Commonds
{
    public class CreateEditProductCommondHandler : IRequestHandler<CreateEditProductCommond, int>
    {
        private readonly IBuyMeDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMediator _mediator;

        public CreateEditProductCommondHandler(IBuyMeDbContext context, ICurrentUserService currentUserService, IMediator mediator)
        {
            _context = context;
            _currentUserService = currentUserService;
            _mediator = mediator;
        }
        public async Task<int> Handle(CreateEditProductCommond request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product product;
            if (request.ProductId.HasValue)
            {
                var entity = await _context.Products.FindAsync(request.ProductId);
                if (entity == null)
                    throw new NotFoundException("Product", request.ProductId);
                product = entity;
            }
            else
            {
                product = new Domain.Entities.Product();
                await _context.Products.AddAsync(product);
                product.CompanyId = _currentUserService.CompanyId;
            }
            product.ProductName = request.ProductName;
            product.Description = request.Description;
            product.Barcode = request.Barcode;
            product.UnitOfMeasureId = request.UnitOfMeasureId;
            product.BranchId = request.BranchId;
            product.CurrencyId = request.CurrencyId;
            product.DefaultBuyingPrice = request.DefaultBuyingPrice;
            product.DefaultSellingPrice = request.DefaultSellingPrice;
            product.CategoryId = request.CategoryId;
            product.AllowMarketing = request.AllowMarketing;
            await _context.SaveChangesAsync(cancellationToken);
            await _mediator.Send(new CreatEditProductImageCommond(product.ProductId,request.ProductImages));
            return product.ProductId;
        }
    }
}
