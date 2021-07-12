using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface IUserManagerService
    {
        Task<IEnumerable<string>> GetCurrentUserRoles();

        Task<(string UserName, string Photo)> GetCurrentUser();
    }
}