using AutoMapper;
using BuyMe.Application.Common.Mapping;
using BuyMe.Domain.Common;

namespace BuyMe.Application.Company.Queries
{
    public class CompanyDto : AuditableEntity, IMapFrom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Business { get; set; }
        public string Logo { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Company, CompanyDto>();
        }
    }
}