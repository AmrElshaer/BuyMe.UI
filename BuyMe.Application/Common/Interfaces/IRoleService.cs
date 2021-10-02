using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface IRoleService
    {

        Task UpSertUserRolesAsync(string userId, IEnumerable<string> roles);

        Task<IEnumerable<string>> GeUserRolesAsync(string userId);
    }
}