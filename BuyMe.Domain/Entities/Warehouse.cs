using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Domain.Entities
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        public int? BranchId { get; set; }
        public Branch Branch { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
