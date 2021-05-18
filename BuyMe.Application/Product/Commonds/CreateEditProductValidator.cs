using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Product.Commonds
{
    public class CreateEditProductValidator : AbstractValidator<CreateEditProductCommond>
    {
        public CreateEditProductValidator()
        {
            RuleFor(d => d.UnitOfMeasureId).NotEmpty();
            RuleFor(d => d.CurrencyId).NotEmpty();
            RuleFor(d => d.ProductName).NotEmpty();
            RuleFor(d => d.CategoryId).NotEmpty();
            RuleFor(d => d.BranchId).NotEmpty();
        }
    }
}
