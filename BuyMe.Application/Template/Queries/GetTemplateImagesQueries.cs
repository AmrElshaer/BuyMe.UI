using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Template.Queries
{
    public class GetTemplateImagesQueries : IRequest<IList<TemplateImagesDto>>
    {
        public GetTemplateImagesQueries(int templateId)
        {
            TemplateId = templateId;
        }

        public int TemplateId { get; private set; }

        public class GetTemplateImagesQueryHandler : IRequestHandler<GetTemplateImagesQueries, IList<TemplateImagesDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetTemplateImagesQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IList<TemplateImagesDto>> Handle(GetTemplateImagesQueries request, CancellationToken cancellationToken)
            {
                var productsImages = await _context.TemplateImages.Where(a => a.TemplateId == request.TemplateId).ToListAsync();
                return _mapper.Map<IList<TemplateImagesDto>>(productsImages);
            }
        }
    }
}