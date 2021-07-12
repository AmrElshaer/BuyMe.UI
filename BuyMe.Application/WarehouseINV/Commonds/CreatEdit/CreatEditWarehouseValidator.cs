using FluentValidation;

namespace BuyMe.Application.WarehouseINV.Commonds.CreatEdit
{
    public class CreatEditWarehouseValidator : AbstractValidator<CreatEditWarehouseCommond>
    {
        public CreatEditWarehouseValidator()
        {
            RuleFor(d => d.WarehouseName).NotEmpty();
            RuleFor(d => d.BranchId).NotEmpty();
        }
    }
}