using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Branch.Commonds.CreatEditBranch
{
    public class CreatEditBranchValidator:AbstractValidator<CreatEditBranchCommond>
    {
        public CreatEditBranchValidator()
        {
            RuleFor(a => a.BranchName).NotEmpty();
            RuleFor(a => a.CurrencyId).NotEmpty();
        }
    }
}
