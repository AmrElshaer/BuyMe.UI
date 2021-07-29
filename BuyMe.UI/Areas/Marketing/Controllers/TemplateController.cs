using BuyMe.Application.Company.Commonds.UpdateTemplate;
using BuyMe.Application.Company.Queries;
using BuyMe.Application.Template.Queries;
using BuyMe.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Marketing.Controllers
{
    public class TemplateController : BaseController
    {
        private readonly MarketingSettings _options;
        public TemplateController(IOptions<MarketingSettings> options)
        {
            _options = options.Value;
        }
        public async Task<IActionResult> Index()
        {
            var templates =await Mediator.Send(new GetTempWithImagesQuery());
            var company = await Mediator.Send(new GetCompanyQuery());
            ViewBag.CompanyTemplate = company?.TemplateId;
            ViewBag.MarketingLink = $"{_options.Domain}{company.Name}";
            return View(templates);
        }
        public async Task<IActionResult> UpdateCompanyTemplate(int templateId)
        {
            await Mediator.Send(new UpdateCompanyTemplateCommond(templateId));
            return Ok();
        }
    }
}
