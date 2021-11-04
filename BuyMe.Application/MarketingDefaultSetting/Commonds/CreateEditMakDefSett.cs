using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.MarketingDefaultSetting.Commonds
{
    public class CreateEditMakDefSett :IRequest<int>
    {
        public int? Id { get; set; }
        public int? CurrencyId { get; set; }
        public int? BranchId { get; set; }
        public int? CustomerTypeId { get; set; }
        public int CompanyId { get; set; }
        public int? SalesTypeId { get; set; }
    }
}
