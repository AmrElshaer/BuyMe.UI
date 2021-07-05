using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Domain.Entities
{
    public class SalesOrder
    {
        public SalesOrder()
        {
            SalesOrderLines = new HashSet<SalesOrderLine>();
        }
        public long SalesOrderId { get; set; }
        public string SalesOrderName { get; set; }
        public int? BranchId { get; set; }
        public Branch Branch { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int? CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public int? SalesTypeId { get; set; }
        public SalesType SalesType { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double Amount { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }
        public double Freight { get; set; }
        public string Remarks { get; set; }
        public string CurrencyCode { get; set; }
        public ICollection<SalesOrderLine> SalesOrderLines { get; set; }
    }
}
