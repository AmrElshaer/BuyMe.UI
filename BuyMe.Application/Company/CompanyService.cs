using BuyMe.Application.Common.Interfaces;
using System.Threading.Tasks;

namespace BuyMe.Application.Company
{
    public class CompanyService : ICompanyService
    {
        private readonly IBuyMeDbContext _context;

        public CompanyService(IBuyMeDbContext context)
        {
            this._context = context;
        }

        public async Task<bool> IsActive(int? companyId)
        {
            return companyId != null ? (await _context.Companies.FindAsync(companyId)).IsActive : true;
        }
    }
}