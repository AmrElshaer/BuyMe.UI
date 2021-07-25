using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Template.Commonds.DeleteTemplate
{
    public class DeleteTemplateCommond:IRequest<Unit>
    {
        public int TemplateId { get; set; }
        public class DeleteTemplateCommondHandler : IRequestHandler<DeleteTemplateCommond, Unit>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IFileService _fileService;

            public DeleteTemplateCommondHandler(IBuyMeDbContext context, IFileService fileService)
            {
                _context = context;
                _fileService = fileService;
            }
            public async Task<Unit> Handle(DeleteTemplateCommond request, CancellationToken cancellationToken)
            {
                var template = await _context.Templates.Include(a => a.Images).FirstOrDefaultAsync(a => a.Id == request.TemplateId);
                _ = template ?? throw new NotFoundException(nameof(Domain.Entities.Template), request.TemplateId);
                _context.Templates.Remove(template);
                await _context.SaveChangesAsync(cancellationToken);
                template.Images.ToList().ForEach(a => _fileService.DeleteFile("images", a.ImageName));
                return Unit.Value;
            }
        }
    }
}
