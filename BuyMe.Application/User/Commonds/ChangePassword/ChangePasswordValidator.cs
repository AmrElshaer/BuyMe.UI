using FluentValidation;

namespace BuyMe.Application.User.Commonds.ChangePassword
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommond>
    {
        public ChangePasswordValidator()
        {
            RuleFor(c => c.OldPassword).NotEmpty().WithMessage("Please enter old password");
            RuleFor(c => c.NewPassword).NotEmpty().WithMessage("Please enter new password");
            RuleFor(c => c.ReTypePassword).NotEmpty().WithMessage("Please retype password");
            RuleFor(c => c.NewPassword).Equal(c => c.ReTypePassword).WithMessage("New Password and Retype Password Not Match");
        }
    }
}
