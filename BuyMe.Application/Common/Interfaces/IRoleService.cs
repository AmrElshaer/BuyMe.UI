using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface IRoleService
    {
        Task GenerateRolesAsync();
        Task UpSertUserRolesAsync(string userId, IEnumerable<string> roles);
        Task<IEnumerable<string>> GeUserRolesAsync(string userId);
    }
}
