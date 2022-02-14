using AutoMapper;
using BuyMe.Application.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.PaymentReceive.Queries
{
    public class PaymentReceiveDto:IMapFrom
    {
        public int PaymentReceiveId { get; set; }
        public string PaymentReceiveName { get; set; }
        public int InvoiceId { get; set; }
        public string InvoiceName { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }

        public double PaymentAmount { get; set; }
        public bool IsFullPayment { get; set; } = true;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.PaymentReceive,PaymentReceiveDto>().ForMember(a => a.InvoiceName,
                pay => pay.MapFrom(a => a.Invoice.InvoiceName))
                .ForMember(a => a.PaymentTypeName, pay => pay.MapFrom(a => a.PaymentType.PaymentTypeName));
        }
    }
}
