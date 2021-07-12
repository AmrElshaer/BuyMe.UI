using FluentValidation;

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