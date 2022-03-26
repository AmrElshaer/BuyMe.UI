using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Branch.Queries
{
    public class GetBranchesQuery : BaseRequestQuery, IRequest<QueryResult<BranchDto>>
    {

        public class GetBranchesQueryHandler : IRequestHandler<GetBranchesQuery, QueryResult<BranchDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetBranchesQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QueryResult<BranchDto>> Handle(GetBranchesQuery req, CancellationToken cancellationToken)
            {
                var res = await _context.Branches.Include(a => a.Currency).ApplyFiliter(req, FilterBranchesQuery(req))
                    .ApplySkip(req).ApplyTake(req).Build(a=>a.BranchId);
                return new QueryResult<BranchDto>() { count = res.Count,
                    result = _mapper.Map<IList<BranchDto>>(res.Data) };
            }

            private static Expression<Func<Domain.Entities.Branch, bool>> FilterBranchesQuery(GetBranchesQuery req)
            {
                return a => a.BranchName.Contains(req.DM.SearchValue) ||
                                    a.Address.Contains(req.DM.SearchValue) ||
                                    a.City.Contains(req.DM.SearchValue) ||
                                    a.Currency.CurrencyName.Contains(req.DM.SearchValue);
            }
        }
    }
}