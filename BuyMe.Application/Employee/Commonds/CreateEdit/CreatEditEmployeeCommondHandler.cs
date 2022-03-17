using BuyMe.Application.Common.Behaviour;
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

            _applicationUserServcie = applicationUserServcie;
        }

        public async Task<int> Handle(CreatEditEmployeeCommond request, CancellationToken cancellationToken)
        {
            Domain.Entities.Employee employee;

            if (request.Id.HasValue)
            {
                var entity = await _context.Employees.FindAsync(request.Id);
                Guard.Against.Null(entity, request.Id);
                await EditApplicationUser(request);
                employee = entity;
            }
            else
            {
                employee = new Domain.Entities.Employee();
                employee.UserId = await AddApplicationUser(request);

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
        private async Task<string> AddApplicationUser(CreatEditEmployeeCommond request)
        {
            return await _applicationUserServcie.AddApplicationUser(new Application.Common.Models.User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Photo = request.Photo,
                UserName = request.Email,
                Email = request.Email,
                CompanyId = request.CompanyId,
                Password = request.Password
            });
        }

        private async Task EditApplicationUser(CreatEditEmployeeCommond request)
        {
            await _applicationUserServcie.EditApplicationUser(new Application.Common.Models.User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Photo = request.Photo,
                UserName = request.Email,
                Email = request.Email,
                CompanyId = request.CompanyId,
                Password = request.Password,
                UserId = request.UserId
            });
        }
    }
}