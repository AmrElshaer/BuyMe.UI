using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Domain.Entities
{
    public class Tenant
    {
        public int Id { get; set; }
        public string TenantName { get; set; }
        public string ConnectionString { get; set; }
    }
}
