using AutoMapper;
using BuyMe.Application.Common.Mapping;
using BuyMe.Application.Product.Queries;
using BuyMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Template.Queries
{
    public class TemplateDto:IMapFrom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<TemplateImagesDto> Images { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Template, TemplateDto>();
        }
    }
}
