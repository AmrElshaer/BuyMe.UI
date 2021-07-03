using AutoMapper;
using BuyMe.Application.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.SalesType.Queries
{
    public class SalesTypeDto : IMapFrom
    {
        public int? Id { get; set; }
        public string SalesTypeName { get; set; }
        public string SalesTypeDescription { get; set; }
        public int CompanyId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.SalesType, SalesTypeDto>();
        }
    }
}
