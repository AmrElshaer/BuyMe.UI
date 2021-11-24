using AutoMapper;
using BuyMe.Application.Common.Mapping;
using BuyMe.Application.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.CustomFieldData.Queries
{
    public class CustomFieldDataDto:IMapFrom
    {
        public int Id { get; set; }
        public int RefranceId { get; set; }
        public IList<CustomColumnModel> Value { get; set; }
        public CustomFieldDataDto()
        {
            Value = new List<CustomColumnModel>();
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.CustomFieldData
                , CustomFieldDataDto>().ForMember(a => a.Value,
                a => a.MapFrom(c => JsonConvert.DeserializeObject(c.Value)));
        }
    }
}
