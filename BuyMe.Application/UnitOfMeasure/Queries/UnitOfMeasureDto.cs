using AutoMapper;
using BuyMe.Application.Common.Mapping;
using BuyMe.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.UnitOfMeasure.Queries
{
    public class UnitOfMeasureDto:IMapFrom
    {
        public int? Id { get; set; }
        public string UOM { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.UnitOfMeasure, UnitOfMeasureDto>();
        }
    }
}
