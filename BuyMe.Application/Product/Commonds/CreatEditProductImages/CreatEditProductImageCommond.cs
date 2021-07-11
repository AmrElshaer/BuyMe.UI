using BuyMe.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Product.Commonds.CreatEditProductImages
{

    public class CreatEditProductImageCommond:IRequest<Unit>
    {
        public int ProductId { get;private set; }
        public List<string> ProductImages { get;private set; }
        public CreatEditProductImageCommond(int productId, List<string> productImages)
        {
            ProductId = productId;
            ProductImages = productImages;
        }

        
        public class CreatEditProductImageCommondHandler : IRequestHandler<CreatEditProductImageCommond, Unit>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IFileService _fileService;
            public CreatEditProductImageCommondHandler(IBuyMeDbContext context, IFileService productImageService)
            {
                _context = context;
                _fileService = productImageService;
            }

            public async Task<Unit> Handle(CreatEditProductImageCommond request, CancellationToken cancellationToken)
            {
                var proImages=await _context.ProductImages.Where(a=>a.ProductId==request.ProductId).ToListAsync();
                proImages.ForEach(a => {
                    if (request.ProductImages.FirstOrDefault(img=>img==a.Image)==null)
                    {
                        _context.ProductImages.Remove(a);
                        _fileService.DeleteFile("images",a.Image);
                    }
                });
                request.ProductImages.ForEach(a => {
                    if (proImages.FirstOrDefault(img => img.Image == a)==null)
                    {
                        _context.ProductImages.Add(new Domain.Entities.ProductImages() { 
                          ProductId=request.ProductId,
                          Image=a
                        });
                    }
                });
                await  _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
