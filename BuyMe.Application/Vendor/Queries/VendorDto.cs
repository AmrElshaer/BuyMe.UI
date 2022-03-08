using AutoMapper;
using BuyMe.Application.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Vendor.Queries
{
    public class VendorDto:IMapFrom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string  VendorTypeNmae { get; set; }
        public int VendorTypeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Vendor, VendorDto>().ForMember(dto=>dto.VendorTypeNmae,ven=>ven.MapFrom(v=>v.VendorType.Name));
        }
    }
}
