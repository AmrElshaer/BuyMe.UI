using BuyMe.Application.Common.Interfaces;
using FluentValidation;

namespace BuyMe.Application.Employee.Commonds.CreateEdit
{
    public class CreatEditEmployeeValidator : AbstractValidator<CreatEditEmployeeCommond>
    {
        private readonly IEmployeeService employeeService;

        public CreatEditEmployeeValidator(IEmployeeService employeeService)
        {
            RuleFor(a => a.FirstName).NotNull();
            RuleFor(a => a.LastName).NotNull();
            RuleFor(a => a.Email).NotNull().EmailAddress().Must(CheckEmail).WithMessage("Email must be unique");
            RuleFor(a => a.Password).NotNull().MinimumLength(8);
            RuleFor(a => a.ConfirmPassword).NotNull().Equal(e => e.Password).WithMessage("Passwords do not match");
            this.employeeService = employeeService;
        }

        private bool CheckEmail(CreatEditEmployeeCommond employeeCommond, string email)
        {
            return employeeService.IsEmailUnique(email, employeeCommond.Id,employeeCommond.CompanyId);
        }
    }
}