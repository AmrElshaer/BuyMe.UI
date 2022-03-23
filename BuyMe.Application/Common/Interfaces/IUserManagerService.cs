using BuyMe.Application.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface IUserManagerService
    {
        Task<IEnumerable<string>> GetCurrentUserRoles();

        Task<Application.Common.Models.User> GetCurrentUser();
        Task UpdateUserPhoto(string photo);
    }
}