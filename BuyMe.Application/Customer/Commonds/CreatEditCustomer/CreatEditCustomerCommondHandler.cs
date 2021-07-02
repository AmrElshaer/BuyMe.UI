using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Customer.Commonds.CreatEditCustomer
{
    public class CreatEditCustomerCommondHandler : IRequestHandler<CreatEditCustomerCommond, int>
    {
        private readonly IBuyMeDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public CreatEditCustomerCommondHandler(IBuyMeDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(CreatEditCustomerCommond request, CancellationToken cancellationToken)
        {
            Domain.Entities.Customer customer;
            if (request.Id.HasValue)
            {
                var entity = await _context.Customers.FindAsync(request.Id);
                if (entity == null)
                    throw new NotFoundException("Customer", request.Id);
                customer = entity;
            }
            else
            {
                customer = new Domain.Entities.Customer();
                await _context.Customers.AddAsync(customer);
                customer.CompanyId = _currentUserService.CompanyId;
            }
            customer.CustomerName = request.CustomerName;
            customer.Email = request.Email;
            customer.Phone = request.Phone;
            customer.CustomerTypeId = request.CustomerTypeId;
            customer.Email = request.Email;
            customer.Address = request.Address;
            customer.City = request.City;
            await _context.SaveChangesAsync(cancellationToken);
            return customer.Id;
        }
    }
}
