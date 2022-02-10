using AutoMapper;
using BuyMe.Application.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Invoice.Queries
{
    public class InvoiceDto : IMapFrom
    {
        public int InvoiceId { get; set; }

        public string InvoiceName { get; set; }

        public long ShipmentId { get; set; }
        public string ShipmentName { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime InvoiceDueDate { get; set; }

        public int? InvoiceTypeId { get; set; }
        public string InvoiceTypeName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Invoice, InvoiceDto>().ForMember(a=>a.ShipmentName,
                inv=>inv.MapFrom(a=>a.Shipment.ShipmentName))
                .ForMember(a=>a.InvoiceTypeName,inv=>inv.MapFrom(a=>a.InvoiceName));
        }
    }
}
