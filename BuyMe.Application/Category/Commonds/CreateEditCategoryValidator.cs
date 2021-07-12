using FluentValidation;

namespace BuyMe.Application.Category.Commonds
{
    public class CreateEditCategoryValidator : AbstractValidator<CreateEditCategoryCommond>
    {
        public CreateEditCategoryValidator()
        {
            RuleFor(d => d.CategoryName).NotEmpty();
        }
    }
}