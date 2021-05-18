using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Branch.Queries
{
    public class GetBranchesQuery:IRequest<QueryResult<BranchDto>>
    {
        public DataManagerRequest DM { get; set; }
        public GetBranchesQuery()
        {
            DM ??= new DataManagerRequest();
        }
        public class GetBranchesQueryHandler : IRequestHandler<GetBranchesQuery, QueryResult<BranchDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService _currentUserService;

            public GetBranchesQueryHandler(IBuyMeDbContext context, IMapper mapper, ICurrentUserService currentUserService)
            {
                _context = context;
                _mapper = mapper;
                _currentUserService = currentUserService;
            }
            public async Task<QueryResult<BranchDto>> Handle(GetBranchesQuery request, CancellationToken cancellationToken)
            {
                var dataSource = _context.Branches.Include(a=>a.Currency).Where(a => a.CompanyId == _currentUserService.CompanyId)
                    .AsQueryable();
                var operation = new DataOperations();
                if (request.DM.Search != null && request.DM.Search.Count > 0) dataSource = operation.PerformSearching(dataSource, request.DM.Search);
                if (request.DM.Skip != 0) dataSource = operation.PerformSkip(dataSource, request.DM.Skip);
                if (request.DM.Take != 0) dataSource = operation.PerformTake(dataSource, request.DM.Take);
                int count = dataSource.Count();
                var currencies = dataSource.OrderByDescending(a => a.CurrencyId).Select(_mapper.Map<BranchDto>).ToList();
                return new QueryResult<BranchDto>() { count = count, result = currencies };
            }

        }
    }
}
