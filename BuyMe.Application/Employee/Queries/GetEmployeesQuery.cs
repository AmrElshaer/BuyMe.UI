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

namespace BuyMe.Application.Employee.Queries
{
    public class GetEmployeesQuery : BaseRequestQuery,IRequest<QueryResult<EmployeeDto>>
    {
        

        public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, QueryResult<EmployeeDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetEmployeesQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QueryResult<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
            {
                var res = await _context.Employees.ApplyFiliter(request,SearchQuery(request))
                    .ApplySkip(request).ApplyTake(request).Build(o=>o.Id);
                return new QueryResult<EmployeeDto>() { count = res.Count, result =_mapper.Map<IList<EmployeeDto>>(res.Data)  };
            }

            private static Expression<Func<Domain.Entities.Employee, bool>> SearchQuery(GetEmployeesQuery request)
            {
                Expression<Func<Domain.Entities.Employee, bool>> expression = a =>
                    a.FirstName.Contains(request.DM.SearchValue) ||
                    a.LastName.Contains(request.DM.SearchValue) ||
                    a.Country.Contains(request.DM.SearchValue) ||
                    a.City.Contains(request.DM.SearchValue);
                return expression;
            }
        }
    }
}