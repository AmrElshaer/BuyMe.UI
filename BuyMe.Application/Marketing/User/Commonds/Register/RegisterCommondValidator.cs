using BuyMe.Application.Common.Interfaces;
using FluentValidation;

namespace BuyMe.Application.Marketing.User.Commonds.Register
{
    public class RegisterCommondValidator : AbstractValidator<RegisterCommond>
    {
        public RegisterCommondValidator(IApplicationUserServcie applicationUser)
        {
            RuleFor(a => a.Email).EmailAddress().NotEmpty();
            RuleFor(a => a).Must(a => !(applicationUser.EmailExistAsync(a.Email, a.CompanyId).GetAwaiter().GetResult())).WithMessage("Email is aleady exist");
        }
    }
}