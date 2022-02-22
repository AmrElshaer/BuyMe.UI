using BuyMe.Application.Employee.Commonds.CreateEdit;
using BuyMe.Application.Employee.Queries;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface IApplicationUserServcie
    {
        Task<string> AddApplicationUser(CreatEditEmployeeCommond creatEditEmployee);

        Task EditApplicationUser(CreatEditEmployeeCommond creatEditEmployee);

        Task RemoveApplicationUser(string id);

        Task<(bool isRegister, string userId)> TryGetUserAsync(string email, int companyId, string password);

        Task<bool> EmailExistAsync(string email, int companyId);
    }
}