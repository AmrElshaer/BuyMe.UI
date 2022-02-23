using BuyMe.Application.Common.Models;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface IApplicationUserServcie
    {
        Task<string> AddApplicationUser(Common.Models.User user);

        Task EditApplicationUser(Common.Models.User user);

        Task RemoveApplicationUser(string id);

        Task<(bool isRegister, string userId)> TryGetUserAsync(string email, int companyId, string password);

        Task<bool> EmailExistAsync(string email, int companyId);
        Task ChangePassword(string userId, string oldPass, string newPass);
    }
}