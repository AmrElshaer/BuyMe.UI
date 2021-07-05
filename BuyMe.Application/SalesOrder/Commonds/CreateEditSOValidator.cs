using BuyMe.Application.SalesOrder.Commonds;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Product.Commonds
{
    public class CreateEditSOValidator : AbstractValidator<CreateEditSOCommond>
    {
        public CreateEditSOValidator()
        {
            RuleFor(d => d.CurrencyId).NotEmpty();
            RuleFor(d => d.BranchId).NotEmpty();
        }
    }
}
