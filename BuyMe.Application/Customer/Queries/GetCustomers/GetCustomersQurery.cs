using System.Collections.Generic;
using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuyMe.Application.Common.Models;
namespace BuyMe.Application.Customer.Queries.GetCustomers
{
    public class GetCustomersQurery :BaseRequestQuery, IRequest<QueryResult<CustomerDto>>
    {
      
        public class GetCustomersQureryHandler : IRequestHandler<GetCustomersQurery, QueryResult<CustomerDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetCustomersQureryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QueryResult<CustomerDto>> Handle(GetCustomersQurery request, CancellationToken cancellationToken)
            {
                var res =await  _context.Customers
                        .Include(a => a.CustomerType)
                    .ApplyFiliter(request,a => a.CustomerName.Contains(request.DM.SearchValue))
                        .ApplySkip(request).ApplyTake(request).Build(o=>o.Id);
                return new QueryResult<CustomerDto>() { count =res.Count, result = _mapper.Map<IList<CustomerDto>>(res.Data ) };
            }
        }
    }
}