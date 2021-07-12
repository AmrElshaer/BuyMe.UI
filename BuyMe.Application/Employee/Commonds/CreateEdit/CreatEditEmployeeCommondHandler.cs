using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Employee.Commonds.CreateEdit
{
    public class CreatEditEmployeeCommondHandler : IRequestHandler<CreatEditEmployeeCommond, int>
    {
        private readonly IBuyMeDbContext _context;
        private readonly IApplicationUserServcie _applicationUserServcie;

        public CreatEditEmployeeCommondHandler(IBuyMeDbContext context, IApplicationUserServcie applicationUserServcie)
        {
            _context = context;
            this._applicationUserServcie = applicationUserServcie;
        }

        public async Task<int> Handle(CreatEditEmployeeCommond request, CancellationToken cancellationToken)
        {
            Domain.Entities.Employee employee;
            if (request.Id.HasValue)
            {
                var entity = await _context.Employees.FindAsync(request.Id);
                if (entity == null)
                    throw new NotFoundException("Employee", request.Id);
                await _applicationUserServcie.EditApplicationUser(request);
                employee = entity;
            }
            else
            {
                employee = new Domain.Entities.Employee();
                employee.UserId = await _applicationUserServcie.AddApplicationUser(request);
                await _context.Employees.AddAsync(employee);
            }
            employee.LastName = request.LastName;
            employee.FirstName = request.FirstName;
            employee.Title = request.Title;
            employee.BirthDate = request.BirthDate;
            employee.HireDate = request.HireDate;
            employee.Address = request.Address;
            employee.City = request.City;
            employee.Region = request.Region;
            employee.Country = request.Country;
            employee.HomePhone = request.HomePhone;
            employee.Photo = request.Photo;
            employee.Notes = request.Notes;
            employee.Email = request.Email;
            employee.Password = request.Password;
            employee.CompanyId = request.CompanyId.Value;
            await _context.SaveChangesAsync(cancellationToken);
            return employee.Id;
        }
    }
}