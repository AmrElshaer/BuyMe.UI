using AutoMapper;
using BuyMe.Application.Common.Mapping;

namespace BuyMe.Application.Branch.Queries
{
    public class BranchDto : IMapFrom
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string Description { get; set; }
        public int CurrencyId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
        public int CompanyId { get; set; }
        public string CurrencyName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Branch, BranchDto>().ForMember(b => b.CurrencyName, b => b.MapFrom(a => a.Currency.CurrencyName));
        }
    }
}