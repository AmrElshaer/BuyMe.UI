using AutoMapper;
using BuyMe.Application.Common.Mapping;
using BuyMe.Application.Product.Queries;
using System.Collections;
using System.Collections.Generic;

namespace BuyMe.Application.Category.Queries
{
    public class CategoryDto : IMapFrom
    {
        public CategoryDto()
        {
            Products = new List<ProductDto>();
        }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public IList<ProductDto> Products { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Category, CategoryDto>();
        }
    }
}