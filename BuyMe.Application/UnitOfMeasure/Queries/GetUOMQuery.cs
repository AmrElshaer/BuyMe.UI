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

namespace BuyMe.Application.UnitOfMeasure.Queries
{
    public  class GetUOMQuery:IRequest<QueryResult<UnitOfMeasureDto>>
    {
        public DataManagerRequest  DM { get; set; }
        public class GetUOMsQueryHandler : IRequestHandler<GetUOMQuery, QueryResult<UnitOfMeasureDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetUOMsQueryHandler(IBuyMeDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<QueryResult<UnitOfMeasureDto>> Handle(GetUOMQuery request, CancellationToken cancellationToken)
            {
                var dataSource = _context.UnitOfMeasures.AsQueryable();
                var operation = new DataOperations();
                if(request.DM.Search != null && request.DM.Search.Count > 0) dataSource = operation.PerformSearching(dataSource, request.DM.Search); 
                if (request.DM.Skip != 0)dataSource = operation.PerformSkip(dataSource, request.DM.Skip);
                if (request.DM.Take != 0)dataSource = operation.PerformTake(dataSource, request.DM.Take);
                int count = dataSource.Count();
                var ums = dataSource.OrderByDescending(a => a.Id).Select(_mapper.Map<UnitOfMeasureDto>).ToList();
                return new QueryResult<UnitOfMeasureDto>() { count=count,result= ums };
            }
            
        }
    }
}
