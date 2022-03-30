using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Company.Queries
{
    public class GetCompanyByNameQuery : IRequest<CompanyDto>
    {
        public string Name { get; private set; }

        public GetCompanyByNameQuery(string name)
        {
            Name = name;
        }

        public class GetCompanyByNameQueryHandler : IRequestHandler<GetCompanyByNameQuery, CompanyDto>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetCompanyByNameQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CompanyDto> Handle(GetCompanyByNameQuery request, CancellationToken cancellationToken)
            {
                return _mapper.Map<CompanyDto>(await _context.Companies.Include(a => a.Template).FirstOrDefaultAsync(a => a.Name == request.Name,cancellationToken));
            }
        }
    }
}