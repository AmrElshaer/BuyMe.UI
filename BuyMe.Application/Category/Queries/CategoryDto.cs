using AutoMapper;
using BuyMe.Application.Common.Mapping;

namespace BuyMe.Application.Category.Queries
{
    public class CategoryDto : IMapFrom
    {
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Category, CategoryDto>();
        }
    }
}