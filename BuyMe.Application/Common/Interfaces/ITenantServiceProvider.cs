using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface ITenantServiceProvider
    {
       string GeneratTenant(string tenant, CancellationToken token = default);
    }
}