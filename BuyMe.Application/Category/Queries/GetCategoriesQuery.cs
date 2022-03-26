using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Category.Queries
{
    public class GetCategoriesQuery : BaseRequestQuery, IRequest<QueryResult<CategoryDto>>
    {

        public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, QueryResult<CategoryDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetCategoriesQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QueryResult<CategoryDto>> Handle(GetCategoriesQuery req, CancellationToken cancellationToken)
            {
                var res =await  _context.Categories.Include(a => a.CategoryDescriptions)
                    .ApplyFiliter(req, a => a.CategoryName.Contains(req.DM.SearchValue)).ApplySkip(req)
                    .ApplyTake(req).Build(i=>i.CategoryId.Value);
              
                return new QueryResult<CategoryDto>() { count = res.Count, result
                    =_mapper.Map<IList<CategoryDto>>(res.Data) };
            }
        }
    }
}