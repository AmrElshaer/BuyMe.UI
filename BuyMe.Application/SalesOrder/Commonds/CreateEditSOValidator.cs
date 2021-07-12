using BuyMe.Application.SalesOrder.Commonds;
using FluentValidation;

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