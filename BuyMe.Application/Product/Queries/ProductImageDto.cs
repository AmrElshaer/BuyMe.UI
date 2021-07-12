using AutoMapper;
using BuyMe.Application.Common.Mapping;
using BuyMe.Domain.Entities;

namespace BuyMe.Application.Product.Queries
{
    public class ProductImageDto : IMapFrom
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductImages, ProductImageDto>();
        }
    }
}