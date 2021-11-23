using AutoMapper;
using BuyMe.Application.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.CustomField.Queries.GetCustomFields
{
    public class CustomFieldDto : IMapFrom
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public int CompanyId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.CustomField,CustomFieldDto>();
        }
    }
}
