using AutoMapper;
using BuyMe.Application.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Template.Queries
{
    public class TemplateImagesDto:IMapFrom
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public int TemplateId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.TemplateImages, TemplateImagesDto>();
        }
    }
}
