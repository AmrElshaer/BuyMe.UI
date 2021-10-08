using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Category.Queries
{
    public class GetCategoryDescriptionQuery : IRequest<IList<CategoryDescriptionDto>>
    {
        public int CategoryId { get; private set; }

        public GetCategoryDescriptionQuery(int categoryId)
        {
            CategoryId = categoryId;
        }

        public class GetProductDescriptionQueryHandler :
            IRequestHandler<GetCategoryDescriptionQuery, IList<CategoryDescriptionDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetProductDescriptionQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IList<CategoryDescriptionDto>> Handle(GetCategoryDescriptionQuery request, CancellationToken cancellationToken)
            {
                var categoryDescriptions = await _context.CategoryDescriptions.Where(a => a.CategoryId == request.CategoryId)
                  .ToListAsync();
                return _mapper.Map<IList<CategoryDescriptionDto>>(categoryDescriptions);
            }
        }
    }
}