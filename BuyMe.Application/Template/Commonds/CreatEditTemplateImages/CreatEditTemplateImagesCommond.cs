using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Product.Commonds.CreatEditProductImages;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Template.Commonds.CreatEditTemplateImages
{
    public class CreatEditTemplateImagesCommond:IRequest<Unit>
    {
        public int TemplateId { get; private set; }
        public List<string> TemplateImages { get; private set; }

        public CreatEditTemplateImagesCommond(int templateId, List<string> templateImages)
        {
            TemplateId = templateId;
            TemplateImages = templateImages;
        }

        public class CreatEditTemplateImagesCommondHandler : IRequestHandler<CreatEditTemplateImagesCommond, Unit>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IFileService _fileService;

            public CreatEditTemplateImagesCommondHandler(IBuyMeDbContext context, IFileService productImageService)
            {
                _context = context;
                _fileService = productImageService;
            }

            public async Task<Unit> Handle(CreatEditTemplateImagesCommond request, CancellationToken cancellationToken)
            {
                var tempImages = await _context.TemplateImages.Where(a => a.TemplateId == request.TemplateId).ToListAsync();
                tempImages.ForEach(a =>
                {
                    if (request.TemplateImages.FirstOrDefault(img => img == a.ImageName) == null)
                    {
                        _context.TemplateImages.Remove(a);
                        _fileService.DeleteFile("images", a.ImageName);
                    }
                });
                request.TemplateImages.ForEach(a =>
                {
                    if (tempImages.FirstOrDefault(img => img.ImageName == a) == null)
                    {
                        _context.TemplateImages.Add(new Domain.Entities.TemplateImages()
                        {
                            TemplateId = request.TemplateId,
                            ImageName = a
                        });
                    }
                });
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
