using BuyMe.Application.Employee.Commonds.CreateEdit;
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