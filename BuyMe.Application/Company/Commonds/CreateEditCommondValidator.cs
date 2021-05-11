using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Company.Commonds
{
    public class CreateEditCommondValidator : AbstractValidator<CreateEditCommond>
    {
        public CreateEditCommondValidator()
        {
            RuleFor(d => d.Name).NotEmpty();
            RuleFor(d => d.Country).NotEmpty();
            RuleFor(d => d.City).NotEmpty();
            RuleFor(d => d.Telephone).NotEmpty();
        }
    }
}
