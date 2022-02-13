using System;

namespace BuyMe.Domain.Entities
{
    public class PaymentReceive
{
        public int PaymentReceiveId { get; set; }
        public string PaymentReceiveName { get; set; }
        public int InvoiceId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentTypeId { get; set; }

        public double PaymentAmount { get; set; }
        public bool IsFullPayment { get; set; } = true;
    }
}
