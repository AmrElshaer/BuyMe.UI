using AutoMapper;
using AutoMapper.QueryableExtensions;
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

namespace BuyMe.Application.Employee.Queries
{
    public class GetEmployeesQuery:IRequest<QueryResult<EmployeeDto>>
    {
        public DataManagerRequest DM { get; set; }
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
                var dataSource = _context.Employees.AsQueryable();
                var operation = new DataOperations();
                int count = dataSource.Count();
                if (request.DM.Search != null && request.DM.Search.Count > 0) dataSource = operation.PerformSearching(dataSource, request.DM.Search);
                if (request.DM.Skip != 0) dataSource = operation.PerformSkip(dataSource, request.DM.Skip);
                if (request.DM.Take != 0) dataSource = operation.PerformTake(dataSource, request.DM.Take);
                var employees =  dataSource.OrderByDescending(a => a.Id).Select(_mapper.Map<EmployeeDto>).ToList();
                return new QueryResult<EmployeeDto>() { count = count, result = employees };
            }

        }
    }
}
