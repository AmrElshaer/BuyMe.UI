using AutoMapper;
using BuyMe.Application.Common.Mapping;

namespace BuyMe.Application.ShipmentType.Queries
{
    public class ShipmentTypeDto : IMapFrom
    {
        public int Id { get; set; }
        public string ShipmentTypeName { get; set; }
        public string ShipmentTypeDescription { get; set; }
        public int CompanyId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.ShipmentType, ShipmentTypeDto>();
        }
    }
}