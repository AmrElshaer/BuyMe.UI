using FluentValidation;

namespace BuyMe.Application.Branch.Commonds.CreatEditBranch
{
    public class CreatEditBranchValidator : AbstractValidator<CreatEditBranchCommond>
    {
        public CreatEditBranchValidator()
        {
            RuleFor(a => a.BranchName).NotEmpty();
            RuleFor(a => a.CurrencyId).NotEmpty();
        }
    }
}