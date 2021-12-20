using AutoMapper;
using BuyMe.Application.Common.Mapping;
using BuyMe.Application.Product.Queries;
using BuyMe.Domain.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BuyMe.Application.Category.Queries
{
    public class CategoryDto : IMapFrom
    {
        public CategoryDto()
        {
            Products = new List<ProductDto>();
            CategoryDescriptions = new List<CategoryDescriptionDto>();
        }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public IList<ProductDto> Products { get; set; }
        public IList<CategoryDescriptionDto> CategoryDescriptions { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Category, CategoryDto>();
        }
       
    }
}