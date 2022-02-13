using AutoMapper;
using BuyMe.Application.Common.Mapping;

namespace BuyMe.Application.PaymentType.Queries
{
    public class PaymentTypeDto : IMapFrom
    {
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public string Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.PaymentType, PaymentTypeDto>();
        }
    }
}
