using AutoMapper;
using BuyMe.Application.Branch.Queries;
using BuyMe.Application.Common.Mapping;
using BuyMe.Application.Company.Queries;
using BuyMe.Application.Currency.Queries;
using BuyMe.Application.CustomerType.Queries;
using BuyMe.Application.SalesType.Queries;

namespace BuyMe.Application.MarketingDefaultSetting.Queries
{
    public class MarketingDefaultSettingDto:IMapFrom
    {
        public int Id { get; set; }
        public int? CurrencyId { get; set; }
        public CurrencyDto Currency { get; set; }
        public int? BranchId { get; set; }
        public BranchDto Branch { get; set; }
        public int? CustomerTypeId { get; set; }
        public CustomerTypeDto CustomerType { get; set; }
        public CompanyDto Company { get; set; }
        public SalesTypeDto SalesType { get; set; }
        public int? SalesTypeId { get; set; }
        public int CompanyId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.MarketingDefaultSetting, MarketingDefaultSettingDto>();
        }
    }
}