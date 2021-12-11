using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Company.Queries;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BuyMe.Application.Company
{
    public class CompanyService : ICompanyService
    {
        private readonly IBuyMeDbContext _context;
        private readonly IMapper mapper;

        public CompanyService(IBuyMeDbContext context, IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
        }

        public async Task<bool> IsActive(int? companyId)
        {
            return companyId != null ? (await _context.Companies.FindAsync(companyId)).IsActive : true;
        }

        public async Task<CompanyDto> GetCurrentCompany()
        {
            return mapper.Map<CompanyDto>(await _context.Companies.FirstOrDefaultAsync());
        }
        
    }
}