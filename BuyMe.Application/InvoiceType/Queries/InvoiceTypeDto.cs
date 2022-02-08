using AutoMapper;
using BuyMe.Application.Common.Mapping;

namespace BuyMe.Application.InvoiceType.Queries
{
    public class InvoiceTypeDto:IMapFrom
    {
        public int InvoiceTypeId { get; set; }
        public string InvoiceTypeName { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.InvoiceType, InvoiceTypeDto>();
        }
    }
}
