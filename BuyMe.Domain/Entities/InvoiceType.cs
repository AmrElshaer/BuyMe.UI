using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Domain.Entities
{
    public class InvoiceType
    {
        public int InvoiceTypeId { get; set; }
        public string InvoiceTypeName { get; set; }
        public string Description { get; set; }
    }
}
