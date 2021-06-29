using AutoMapper;
using AutoMapper.QueryableExtensions;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Employee.Queries
{
    public class GetEmployeesQuery:IRequest<QueryResult<EmployeeDto>>
    {
        public DataManager DM { get; set; }
        public int CompanyId { get; set; }
        public GetEmployeesQuery()
        {
            DM ??= new DataManager();
        }
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
                var dataSource = _context.Employees.Where(a=>a.CompanyId==request.CompanyId).AsQueryable();
                if (!string.IsNullOrEmpty(request.DM.SearchValue)) 
                { 
                    dataSource = dataSource.Where(a => a.FirstName.Contains(request.DM.SearchValue)||
                     a.LastName.Contains(request.DM.SearchValue)||
                     a.Country.Contains(request.DM.SearchValue)||
                     a.City.Contains(request.DM.SearchValue) 
                    ); 
                }
                if (request.DM.Skip !=null && request.DM.Skip != 0) dataSource = dataSource.Skip(request.DM.Skip.Value);
                if (request.DM.Take != null && request.DM.Take != 0) dataSource = dataSource.Take(request.DM.Take.Value);
                int count = dataSource.Count();
                var employees =  dataSource.OrderByDescending(a => a.Id).Select(_mapper.Map<EmployeeDto>).ToList();
                return new QueryResult<EmployeeDto>() { count = count, result = employees };
            }

        }
    }
}
