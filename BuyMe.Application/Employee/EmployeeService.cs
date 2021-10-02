using BuyMe.Application.Common.Interfaces;
using System.Linq;

namespace BuyMe.Application.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IBuyMeDbContext _context;

        public EmployeeService(IBuyMeDbContext context)
        {
            this._context = context;
        }

        public bool IsEmailUnique(string email, int? id,int? companyId)
        {
            var employee = _context.Employees.FirstOrDefault(a => a.Email == email&&a.CompanyId==companyId && (id == null || a.Id != id));
            return employee == null ? true : false;
        }
    }
}