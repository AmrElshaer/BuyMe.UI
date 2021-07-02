using AutoMapper;
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

namespace BuyMe.Application.Customer.Queries.GetCustomers
{
    public class GetCustomersQurery:IRequest<QueryResult<CustomerDto>>
    {
        public DataManager DM { get; set; }
        public GetCustomersQurery()
        {
            DM ??= new DataManager();
        }
        public class GetCustomersQureryHandler:IRequestHandler<GetCustomersQurery, QueryResult<CustomerDto>>
        {
                private readonly IBuyMeDbContext _context;
                private readonly IMapper _mapper;
                private readonly ICurrentUserService _currentUserService;

                public GetCustomersQureryHandler(IBuyMeDbContext context, IMapper mapper, ICurrentUserService currentUserService)
                {
                    _context = context;
                    _mapper = mapper;
                    _currentUserService = currentUserService;
                }
                public async Task<QueryResult<CustomerDto>> Handle(GetCustomersQurery request, CancellationToken cancellationToken)
                {
                    var dataSource = _context.Customers.Include(a=>a.CustomerType).Where(a => a.CompanyId == _currentUserService.CompanyId)
                        .AsQueryable();
                    if (!string.IsNullOrEmpty(request.DM.SearchValue))
                    {
                        dataSource = dataSource.Where(a => a.CustomerName.Contains(request.DM.SearchValue));
                    }
                    if (request.DM.Skip != null && request.DM.Skip != 0) dataSource = dataSource.Skip(request.DM.Skip.Value);
                    if (request.DM.Take != null && request.DM.Take != 0) dataSource = dataSource.Take(request.DM.Take.Value);
                    int count = dataSource.Count();
                    var currencies = dataSource.OrderByDescending(a => a.Id).Select(_mapper.Map<CustomerDto>).ToList();
                    return new QueryResult<CustomerDto>() { count = count, result = currencies };
                }
        }
        
    }
}
