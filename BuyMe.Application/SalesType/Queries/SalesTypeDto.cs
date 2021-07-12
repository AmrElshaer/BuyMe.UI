using AutoMapper;
using BuyMe.Application.Common.Mapping;

namespace BuyMe.Application.SalesType.Queries
{
    public class SalesTypeDto : IMapFrom
    {
        public int? Id { get; set; }
        public string SalesTypeName { get; set; }
        public string SalesTypeDescription { get; set; }
        public int CompanyId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.SalesType, SalesTypeDto>();
        }
    }
}