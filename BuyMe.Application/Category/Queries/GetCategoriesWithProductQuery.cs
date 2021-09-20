using AutoMapper;
using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Employee.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Category.Queries
{
    public class GetCategoriesWithProductQuery : IRequest<IList<CategoryDto>>
    {
        
        public GetCategoriesWithProductQuery(string companName)
        {
            CompanName = companName;
        }

        public string CompanName { get; }

        public class GetCategoriesWithProductQueryHandler : IRequestHandler<GetCategoriesWithProductQuery, IList<CategoryDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetCategoriesWithProductQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IList<CategoryDto>> Handle(GetCategoriesWithProductQuery req, 
                CancellationToken cancellationToken)
            {
                var comapny = await  _context.Companies.FirstOrDefaultAsync(a=>a.Name==req.CompanName);
                Guard.Against.Null(comapny,comapny.Name);
                var result = _context.Categories.Where(a => a.CompanyId== comapny.Id)
                    .Include(a=>a.Products).ThenInclude(a=>a.ProductImages)
                    .Include(a=>a.Products).ThenInclude(a=>a.Currency)
                    .Select(_mapper.Map<CategoryDto>).ToList();
               
                return result;
            }
        }
    }
}
