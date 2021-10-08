using AutoMapper;
using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Product.Commonds.CreatEditProductImages;
using BuyMe.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Product.Commonds
{
    public class CreateEditProductCommondHandler : IRequestHandler<CreateEditProductCommond, int>
    {
        private readonly IBuyMeDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMediator _mediator;
        private readonly IMapper mapper;

        public CreateEditProductCommondHandler(IBuyMeDbContext context, ICurrentUserService currentUserService, IMediator mediator,IMapper 
            mapper)
        {
            _context = context;
            _currentUserService = currentUserService;
            _mediator = mediator;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateEditProductCommond request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product product;
            if (request.ProductId.HasValue)
            {
                var entity = await _context.Products.Include(a=>a.ProductDescriptions).FirstOrDefaultAsync(a=>a.ProductId==request.ProductId);
                Guard.Against.Null(entity, request.ProductId);
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
            product.UpSertProductDescs(mapper.Map<IList<ProductDescription>>(request.ProductDescriptions));
            await _context.SaveChangesAsync(cancellationToken);
            await _mediator.Send(new CreatEditProductImageCommond(product.ProductId, request.ProductImages));
            return product.ProductId;
        }
    }
}