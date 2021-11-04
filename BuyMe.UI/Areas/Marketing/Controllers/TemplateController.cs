using BuyMe.Application.Common.Models;
using BuyMe.Application.Company.Commonds.UpdateTemplate;
using BuyMe.Application.Company.Queries;
using BuyMe.Application.Template.Queries;
using BuyMe.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Marketing.Controllers
{
    [Authorize(Roles = ApplicationRoles.Template)]
    public class TemplateController : BaseController
    {
        private readonly MarketingSettings _options;

        public TemplateController(IOptions<MarketingSettings> options)
        {
            _options = options.Value;
        }

        public async Task<IActionResult> Index()
        {
            var templates = await Mediator.Send(new GetTempWithImagesQuery());
            var company = await Mediator.Send(new GetCompanyQuery());
            ViewBag.CompanyTemplate = company?.TemplateId;
            ViewBag.MarketingLink = $"{_options.Domain}/{company.Name}/{(HttpContext.Request.Cookies.TryGetValue("tenant",out var tenant)?tenant:"Default")}";
            return View(templates);
        }

        public async Task<IActionResult> UpdateCompanyTemplate(int templateId)
        {
            await Mediator.Send(new UpdateCompanyTemplateCommond(templateId));
            return Ok();
        }
    }
}