using FluentValidation;

namespace BuyMe.Application.Currency.Commonds.CreateEditCurrency
{
    public class CreatEditCurrencyValidator : AbstractValidator<CreatEditCurrencyCommond>
    {
        public CreatEditCurrencyValidator()
        {
            RuleFor(a => a.CurrencyName).NotEmpty();
            RuleFor(a => a.CurrencyCode).NotEmpty();
        }
    }
}