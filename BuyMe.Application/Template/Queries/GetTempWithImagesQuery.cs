using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Template.Queries
{
    public class GetTempWithImagesQuery:IRequest<IList<TemplateDto>>
    {
        public class GetTempWithImagesQueryHandler : IRequestHandler<GetTempWithImagesQuery, IList<TemplateDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetTempWithImagesQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IList<TemplateDto>> Handle(GetTempWithImagesQuery request, CancellationToken cancellationToken)
            {
                var templates= await  _context.Templates.Include(a=>a.Images).ToListAsync();
                return _mapper.Map<IList<TemplateDto>>(templates);
            }
        }
    }
}
