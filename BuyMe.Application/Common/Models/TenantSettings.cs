using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Models
{
    public class TenantSettings
    {
        public string DefaultConnection { get; set; }
        public List<Tenant> Tenants { get; set; }
    }
    public class Tenant
    {
        public string Name { get; set; }
        public string ConnectionString { get; set; }
    }
   
}
