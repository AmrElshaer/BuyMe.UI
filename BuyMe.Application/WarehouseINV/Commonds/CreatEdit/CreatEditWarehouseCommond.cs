using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.WarehouseINV.Commonds.CreatEdit
{
    public class CreatEditWarehouseCommond:IRequest<int>
    {
        public int? WarehouseId { get; set; }
        public int? BranchId { get; set; }
        public string WarehouseName { get; set; }
        public string Description { get; set; }
        public int? CompanyId { get; set; }
       
    }
}
