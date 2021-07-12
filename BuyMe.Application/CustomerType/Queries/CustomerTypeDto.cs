using AutoMapper;
using BuyMe.Application.Common.Mapping;

namespace BuyMe.Application.CustomerType.Queries
{
    public class CustomerTypeDto : IMapFrom
    {
        public int? Id { get; set; }
        public string CustomerTypeName { get; set; }
        public string CustomerTypeDescription { get; set; }
        public int CompanyId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.CustomerType, CustomerTypeDto>();
        }
    }
}