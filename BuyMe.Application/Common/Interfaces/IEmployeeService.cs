using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface IEmployeeService
    {
        bool IsEmailUnique(string email,int? id);
    }
}
