using BuyMe.Application.Employee.Commonds.CreateEdit;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface IApplicationUserServcie
    {
        Task<string> AddApplicationUser(string firstName,string lastName,string password,string email,int companyId,string photo=null);

        Task EditApplicationUser(string userId,string firstName, string lastName, string password, string email, int companyId, string photo=null);

        Task RemoveApplicationUser(string id);

        Task<(bool isRegister, string userId)> TryGetUserAsync(string email, string password);
    }
}