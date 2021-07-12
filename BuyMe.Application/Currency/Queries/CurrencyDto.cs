using AutoMapper;
using BuyMe.Application.Common.Mapping;

namespace BuyMe.Application.Currency.Queries
{
    public class CurrencyDto : IMapFrom
    {
        public int? CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Currency, CurrencyDto>();
        }
    }
}