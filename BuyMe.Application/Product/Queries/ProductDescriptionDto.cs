using AutoMapper;
using BuyMe.Application.Category.Queries;
using BuyMe.Application.Common.Mapping;
using BuyMe.Domain.Entities;

namespace BuyMe.Application.Product.Queries
{
    public class ProductDescriptionDto : IMapFrom
    {
        public int Id { get; set; } 
        public int? ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int? CategoryDescriptionId { get; set; }
        public CategoryDescriptionDto CategoryDescription { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductDescription, ProductDescriptionDto>().ReverseMap();
        }
    }
}