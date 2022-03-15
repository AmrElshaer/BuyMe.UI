using AutoMapper;
using BuyMe.Application.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.PurchaseType.Queries
{
    public class PurchaseTypeDto:IMapFrom
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.PurchaseType, PurchaseTypeDto>();
        }
    }
}
