using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Currency.Commonds.CreateEditCurrency
{
    public class CreatEditCurrencyValidator:AbstractValidator<CreatEditCurrencyCommond>
    {
        public CreatEditCurrencyValidator()
        {
            RuleFor(a => a.CurrencyName).NotEmpty();
            RuleFor(a => a.CurrencyCode).NotEmpty();
        }
    }
}
