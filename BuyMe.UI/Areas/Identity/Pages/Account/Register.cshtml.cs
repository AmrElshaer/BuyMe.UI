using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Company.Commonds;
using BuyMe.Application.Company.Commonds.DeleteCompany;
using BuyMe.Application.Employee.Commonds.CreateEdit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IMediator mediator;

        public RegisterModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [BindProperty]
        public CreateEditCompanyCommond companyCommond { get; set; }

        [BindProperty]
        public CreatEditEmployeeCommond employeeCommond { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            return (await TryRegisterUser()) ? RedirectToPage("./Login") : Page();
        }
        async Task<bool> TryRegisterUser()
        {
            return (await TryAddCompany()) && (await TryAddEmployee());
        }
        private async Task<bool> TryAddEmployee()
        {
            try
            {
                employeeCommond.CompanyId = companyCommond.Id;
                await mediator.Send(employeeCommond);
            }
            catch (ValidationException validationException)
            {
                AddValidation(validationException);

                await mediator.Send(new DeleteCompanyCommond() { CompanyId = companyCommond.Id.Value });
                companyCommond.Id = null;
                return false;

            }
            return true;
        }

        private void AddValidation(ValidationException validationException)
        {
            foreach (var item in validationException.Failures)
            {
                ModelState.AddModelError(item.Key, item.Value[0]);
            }
        }

        private async Task<bool> TryAddCompany()
        {
            try
            {
                companyCommond.IsActive = true;
                companyCommond.Id = await mediator.Send(companyCommond);
            }
            catch (ValidationException validationException)
            {

                AddValidation(validationException);
                return false;

            }
            return true;
        }
    }
}