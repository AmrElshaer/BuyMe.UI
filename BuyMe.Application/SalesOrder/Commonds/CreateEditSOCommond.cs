using MediatR;
using System;

namespace BuyMe.Application.SalesOrder.Commonds
{
    public class CreateEditSOCommond : IRequest<long>
    {
        public long? SalesOrderId { get; set; }
        public int? BranchId { get; set; }
        public int CompanyId { get; set; }
        public int? CurrencyId { get; set; }
        public int? SalesTypeId { get; set; }
        public int? CustomerId { get; set; }
        public string SalesOrderName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string CurrencyCode { get; set; }
        public double Amount { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }
        public double Freight { get; set; }
        public string Remarks { get; set; }
    }
}