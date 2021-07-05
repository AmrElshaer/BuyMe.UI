using AutoMapper;
using BuyMe.Application.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.NumberSequence.Queries
{
    public class NumberSequenceDto:IMapFrom
    {
        public int NumberSequenceId { get; set; }
        public string NumberSequenceName { get; set; }
        public string Module { get; set; }
        public string Prefix { get; set; }
        public int LastNumber { get; set; }
        public int CompanyId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.NumberSequence, NumberSequenceDto>();
        }
    }
}
