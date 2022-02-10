using System;

namespace BuyMe.Domain.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public string InvoiceName { get; set; }

        public long ShipmentId { get; set; }
        public Shipment Shipment { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime InvoiceDueDate { get; set; }

        public int? InvoiceTypeId { get; set; }
        public InvoiceType InvoiceType { get; set; }
    }
}