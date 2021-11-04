using AutoMapper;
using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Customer.Queries.GetCustomers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Customer.Queries
{
    public class GetCustomerByIdQuery :IRequest<CustomerDto>
    {
        public GetCustomerByIdQuery(int customerId)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; init; }
        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
        {
            private readonly IBuyMeDbContext context;
            private readonly IMapper mapper;

            public GetCustomerByIdQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
            {
                var customer = await this.context.Customers.FindAsync(request.CustomerId);
                Guard.Against.Null(customer,"CustomerId");
                return mapper.Map<CustomerDto>(customer);
            }
        }
    }
}
