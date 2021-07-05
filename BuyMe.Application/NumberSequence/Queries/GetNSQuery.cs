using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.NumberSequence.Queries
{
    public class GetNSQuery:IRequest<NumberSequenceDto>
    {
        public GetNSQuery(string module)
        {
            Module = module ?? throw new ArgumentNullException(nameof(module));
        }

        public string Module { get;private set; }

        public class GetNSQueryHandler : IRequestHandler<GetNSQuery, NumberSequenceDto>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService _currentUserService;

            public GetNSQueryHandler(IBuyMeDbContext context, IMapper mapper, ICurrentUserService currentUserService)
            {
                _context = context;
                _mapper = mapper;
                _currentUserService = currentUserService;
            }
            public async   Task<NumberSequenceDto> Handle(GetNSQuery request, CancellationToken cancellationToken)
            {
               var ns=await  _context.NumberSequences.FirstOrDefaultAsync(a => a.CompanyId == _currentUserService.CompanyId&&a.Module==request.Module);
                return _mapper.Map<NumberSequenceDto>(ns);
               
            }
        }
    }
}
