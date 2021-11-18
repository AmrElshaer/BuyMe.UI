using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Domain.Entities
{
    public class ShipmentType
    {
        public int Id { get; set; }
        public string ShipmentTypeName { get; set; }
        public string ShipmentTypeDescription { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
