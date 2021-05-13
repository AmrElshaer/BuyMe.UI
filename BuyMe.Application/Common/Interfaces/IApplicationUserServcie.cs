using BuyMe.Application.Employee.Commonds.CreateEdit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface IApplicationUserServcie
    {
        Task<string> AddApplicationUser(CreatEditEmployeeCommond employee);
        Task EditApplicationUser(CreatEditEmployeeCommond employee);
        Task RemoveApplicationUser(string id);
    }
}
