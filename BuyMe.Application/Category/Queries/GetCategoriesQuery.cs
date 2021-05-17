using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Syncfusion.EJ2.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace BuyMe.Application.Category.Queries
{
    public  class GetCategoriesQuery:IRequest<QueryResult<CategoryDto>>
    {
        public DataManagerRequest  DM { get; set; }
        public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, QueryResult<CategoryDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetCategoriesQueryHandler(IBuyMeDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<QueryResult<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
            {
                var dataSource = _context.Categories.AsQueryable();
                var operation = new DataOperations();
                if(request.DM.Search != null && request.DM.Search.Count > 0) dataSource = operation.PerformSearching(dataSource, request.DM.Search); 
                if (request.DM.Skip != 0)dataSource = operation.PerformSkip(dataSource, request.DM.Skip);
                if (request.DM.Take != 0)dataSource = operation.PerformTake(dataSource, request.DM.Take);
                int count = dataSource.Count();
                var categories = dataSource.OrderByDescending(a => a.CategoryId).Select(_mapper.Map<CategoryDto>).ToList();
                return new QueryResult<CategoryDto>() { count=count,result= categories };
            }
            
        }
    }
}
