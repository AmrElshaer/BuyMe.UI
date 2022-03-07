using AutoMapper;
using BuyMe.Application.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.VendorType.Queries
{
    public class VendorTypeDto:IMapFrom
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.VendorType, VendorTypeDto>();
        }
    }
}
