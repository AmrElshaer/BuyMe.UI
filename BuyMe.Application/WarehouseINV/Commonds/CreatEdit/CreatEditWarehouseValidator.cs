using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.WarehouseINV.Commonds.CreatEdit
{
    public class CreatEditWarehouseValidator : AbstractValidator<CreatEditWarehouseCommond>
    {
        public CreatEditWarehouseValidator()
        {
            RuleFor(d => d.WarehouseName).NotEmpty();
            RuleFor(d => d.BranchId).NotEmpty();
        }
    }
}
