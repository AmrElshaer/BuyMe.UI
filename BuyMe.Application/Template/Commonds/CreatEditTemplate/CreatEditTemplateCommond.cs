using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Product.Commonds.CreatEditProductImages;
using BuyMe.Application.Template.Commonds.CreatEditTemplateImages;
using BuyMe.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Template.Commonds.CreatEditTemplate
{
    public class CreatEditTemplateCommond:IRequest<int>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public CreatEditTemplateCommond()
        {
            Images ??= new List<string>();
        }
        public class CreatEditTemplateCommondHandler : IRequestHandler<CreatEditTemplateCommond, int>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMediator _mediator;

            public CreatEditTemplateCommondHandler(IBuyMeDbContext context, ICurrentUserService currentUserService, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }
            public async Task<int> Handle(CreatEditTemplateCommond request, CancellationToken cancellationToken)
            {
                Domain.Entities.Template template;
                if (request.Id.HasValue)
                {
                    var entity = await _context.Templates.FindAsync(request.Id);
                    Guard.Against.Null(entity, request.Id);
                    template = entity;
                }
                else
                {
                    template = new Domain.Entities.Template();
                    await _context.Templates.AddAsync(template);
                }
                template.Name = request.Name;
                template.Description = request.Description;
                await _context.SaveChangesAsync(cancellationToken);
                await _mediator.Send(new CreatEditTemplateImagesCommond(template.Id, request.Images));
                return template.Id;
            }
        }
    }
}
