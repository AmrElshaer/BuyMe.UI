using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface ICompanyService
    {
        Task<bool> IsActive(int? companyId);
    }
}