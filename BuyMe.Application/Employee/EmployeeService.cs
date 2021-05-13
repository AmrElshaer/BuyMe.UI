using BuyMe.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IBuyMeDbContext _context;

        public EmployeeService(IBuyMeDbContext context)
        {
            this._context = context;
        }
        public bool IsEmailUnique(string email,int? id)
        {
            var employee = _context.Employees.FirstOrDefault(a=>a.Email==email&&(id==null||a.Id!=id));
            return employee==null?true: false;
        }
    }
}
