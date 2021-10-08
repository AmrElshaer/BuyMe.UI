using AutoMapper;
using BuyMe.Application.Common.Mapping;
using BuyMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Category.Queries
{
    public class CategoryDescriptionDto:IMapFrom
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public int CompanyId { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CategoryDescription, CategoryDescriptionDto>();

        }
    }
}
