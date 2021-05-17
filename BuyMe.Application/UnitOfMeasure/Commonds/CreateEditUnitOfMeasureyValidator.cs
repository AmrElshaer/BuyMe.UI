using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.UnitOfMeasure.Commonds
{
    public class CreateEditUnitOfMeasureyValidator : AbstractValidator<CreateEditUnitOfMeasureCommond>
    {
        public CreateEditUnitOfMeasureyValidator()
        {
            RuleFor(d => d.UOM).NotEmpty();
        }
    }
}
