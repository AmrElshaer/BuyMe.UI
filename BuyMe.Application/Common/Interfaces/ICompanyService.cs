using BuyMe.Application.Company.Queries;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface ICompanyService
    {
        Task<CompanyDto> GetCurrentCompany();

        Task<bool> IsActive(int? companyId);
    }
}