
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Company.Commonds
{
    public class CreateEditCommondHandler : IRequestHandler<CreateEditCommond, int>
    {
        private readonly IBuyMeDbContext _context;
        public CreateEditCommondHandler(IBuyMeDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateEditCommond request, CancellationToken cancellationToken)
        {
            Domain.Entities.Company company;
            if (request.Id.HasValue)
            {
                var entity = await _context.Companies.FindAsync(request.Id);
                if (entity == null)
                    throw new NotFoundException("Company", request.Id);
                company = entity;
            }
            else
            {
                company = new Domain.Entities.Company();
                await _context.Companies.AddAsync(company);
            }
            company.Country = request.Country;
            company.City = request.City;
            company.Business = request.Business;
            company.Logo = request.Logo;
            company.IsActive = request.IsActive;
            company.Name = request.Name;
            company.Telephone = request.Telephone;
            await _context.SaveChangesAsync(cancellationToken);
            return company.Id;
        }
    }
}
