using BuyMe.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.UnitOfMeasure.Commonds
{
    public class CreateEditUnitOfMeasureCommond: IRequest<int>
    {
        public int? Id { get; set; }
        public string UOM { get; set; }
        public string Description { get; set; }
        public int? CompanyId { get; set; }
    }
}
