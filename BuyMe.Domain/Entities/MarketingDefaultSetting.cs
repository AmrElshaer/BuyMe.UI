using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Domain.Entities
{
    public class MarketingDefaultSetting
    {
        public int Id { get; set; }
        public int? CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public int? BranchId { get; set; }
        public Branch Branch { get; set; }
        public int? CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; }
        public SalesType SalesType { get; set; }
        public int? SalesTypeId { get; set; }
        public Company Company { get; set; }
        public  int CompanyId { get; set; }
    }
}
