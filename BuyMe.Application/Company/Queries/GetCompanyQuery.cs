using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Company.Queries
{
    public class GetCompanyQuery : IRequest<CompanyDto>
    {
        public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, CompanyDto>
        {
            private readonly IBuyMeDbContext _context;
            private readonly ICurrentUserService _currentUserService;
            private readonly IMapper _mapper;

            public GetCompanyQueryHandler(IBuyMeDbContext context, ICurrentUserService currentUserService, IMapper mapper)
            {
                _context = context;
                _currentUserService = currentUserService;
                _mapper = mapper;
            }

            public async Task<CompanyDto> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
            {
                return _mapper.Map<CompanyDto>(await _context.Companies.FindAsync(_currentUserService.CompanyId));
            }
        }
    }
}