using System;
using System.Collections.Generic;
using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Company.Queries
{
    public class GetCompaniesQuery : BaseRequestQuery,IRequest<QueryResult<CompanyDto>>
    {
       

        public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery, QueryResult<CompanyDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetCompaniesQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QueryResult<CompanyDto>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
            {
                var res =await _context.Companies.ApplyFiliter(request, SearchQuery(request))
                    .ApplySkip(request).ApplyTake(request).Build(a => a.Id);
                return new QueryResult<CompanyDto>() { count = res.Count, 
                    result =_mapper.Map<IList<CompanyDto>>(res.Data)  };
            }

            private Expression<Func<Domain.Entities.Company, bool>> SearchQuery(GetCompaniesQuery request)
            {
                Expression<Func<Domain.Entities.Company, bool>> expression = a => a.Name.Contains(request.DM.SearchValue) ||
                    a.Country.Contains(request.DM.SearchValue) ||
                    a.City.Contains(request.DM.SearchValue) ||
                    a.Business.Contains(request.DM.SearchValue);
                return expression;
            }
        }
    }
}