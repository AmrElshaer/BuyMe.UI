using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Company.Queries
{
    public  class GetCompaniesQuery:IRequest<QueryResult<CompanyDto>>
    {
        public DataManager  DM { get; set; }
        public GetCompaniesQuery()
        {
            DM ??= new DataManager();
        }
        public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery, QueryResult<CompanyDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetCompaniesQueryHandler(IBuyMeDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<QueryResult<CompanyDto>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
            {
                var dataSource = _context.Companies.AsQueryable();
                if (!string.IsNullOrEmpty(request.DM.SearchValue))
                {
                    dataSource = dataSource.Where(a =>a.Name.Contains(request.DM.SearchValue)||
                    a.Country.Contains(request.DM.SearchValue)||
                    a.City.Contains(request.DM.SearchValue)||
                    a.Business.Contains(request.DM.SearchValue));
                }
                if (request.DM.Skip!=null&&request.DM.Skip != 0)dataSource = dataSource.Skip(request.DM.Skip.Value);
                if (request.DM.Take != null && request.DM.Take != 0)dataSource = dataSource.Take(request.DM.Take.Value);
                int count = dataSource.Count();
                var companies = dataSource.OrderByDescending(a => a.Id).Select(_mapper.Map<CompanyDto>).ToList();
                return new QueryResult<CompanyDto>() { count=count,result= companies };
            }
            
        }
    }
}
