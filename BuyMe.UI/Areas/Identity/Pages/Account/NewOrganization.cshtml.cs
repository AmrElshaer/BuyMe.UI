using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Company.Commonds;
using BuyMe.Application.TenantSetting.Commonds.UpSertTenant;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BuyMe.UI.Areas.Identity.Pages.Account
{
    
    public class NewOrganizationModel : PageModel
    {
        private readonly IMediator mediator;

        public NewOrganizationModel(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [BindProperty]
        public CreateEditCompanyCommond CompanyCommond { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            return (await TryAddCompany()) ? RedirectToPage("./Register") : Page();

        }
        private async Task<bool> TryAddCompany()
        {
            try
            {
                await mediator.Send(new UpSertTenantCommond() { TenantName = CompanyCommond.Name,TenantLogo=CompanyCommond.Logo });
                HttpContext.Response.Cookies.Append("tenant", CompanyCommond.Name);
                HttpContext.Session.SetString("tenant", CompanyCommond.Name);
                CompanyCommond.IsActive = true;
                CompanyCommond.Id = await mediator.Send(CompanyCommond);
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
