using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Company.Commonds;
using BuyMe.Application.Company.Commonds.DeleteCompany;
using BuyMe.Application.Employee.Commonds.CreateEdit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace ByMe.Presentation.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IMediator mediator;
        private readonly ICompanyService companyService;

        public RegisterModel(IMediator mediator, ICompanyService companyService)
        {
            this.mediator = mediator;
            this.companyService = companyService;
        }

        [BindProperty]
        public CreatEditEmployeeCommond employeeCommond { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            return (await TryAddEmployee()) ? RedirectToPage("./Login") : Page();
        }
       
        private async Task<bool> TryAddEmployee()
        {
            try
            {
                employeeCommond.CompanyId = (await companyService.GetCurrentCompany())?.Id;
                await mediator.Send(employeeCommond);
            }
            catch (ValidationException validationException)
            {
                AddValidation(validationException);
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

       
    }
}