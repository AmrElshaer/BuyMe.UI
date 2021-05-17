using AutoMapper;
using BuyMe.Application.Common.Mapping;
using BuyMe.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Category.Queries
{
    public class CategoryDto:IMapFrom
    {
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Category,CategoryDto>();
        }
    }
}
