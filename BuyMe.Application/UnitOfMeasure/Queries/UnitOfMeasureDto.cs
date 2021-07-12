using AutoMapper;
using BuyMe.Application.Common.Mapping;

namespace BuyMe.Application.UnitOfMeasure.Queries
{
    public class UnitOfMeasureDto : IMapFrom
    {
        public int? Id { get; set; }
        public string UOM { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.UnitOfMeasure, UnitOfMeasureDto>();
        }
    }
}