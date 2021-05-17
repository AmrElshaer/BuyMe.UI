using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Category.Commonds
{
    public class CreateEditCategoryValidator : AbstractValidator<CreateEditCategoryCommond>
    {
        public CreateEditCategoryValidator()
        {
            RuleFor(d => d.CategoryName).NotEmpty();
            RuleFor(d => d.Description).NotEmpty();
        }
    }
}
