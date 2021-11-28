using BuyMe.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface ITenantService
    {
        public string GetConnectionString();
        public TenantDto GetTenant();
    }
}
