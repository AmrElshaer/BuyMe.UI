using AutoMapper;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Currency.Queries
{
    public class GetBranchCurrencyQuery:IRequest<CurrencyDto>
    {
        public int BranchId { get; set; }
        public class GetBranchCurrencyQueryHandler : IRequestHandler<GetBranchCurrencyQuery, CurrencyDto>
        {
            private readonly IBuyMeDbContext context;
            private readonly IMapper mapper;

            public GetBranchCurrencyQueryHandler(IBuyMeDbContext context,IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }
            public async Task<CurrencyDto> Handle(GetBranchCurrencyQuery request, CancellationToken cancellationToken)
            {
                var branch =await context.Branches.Include(a=>a.Currency).FirstOrDefaultAsync(a=>a.BranchId==request.BranchId);
                if (branch == null)
                {
                    throw new NotFoundException("Currency",request.BranchId);
                }
                return mapper.Map<CurrencyDto>(branch.Currency);
            }
        }
    }
}
