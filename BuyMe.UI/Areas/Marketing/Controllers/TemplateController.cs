using BuyMe.Application.Company.Commonds.UpdateTemplate;
using BuyMe.Application.Company.Queries;
using BuyMe.Application.Template.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Marketing.Controllers
{
    public class TemplateController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            var templates =await Mediator.Send(new GetTempWithImagesQuery());
            ViewBag.CompanyTemplate = (await Mediator.Send(new GetCompanyQuery()))?.TemplateId;
            return View(templates);
        }
        public async Task<IActionResult> UpdateCompanyTemplate(int templateId)
        {
            await Mediator.Send(new UpdateCompanyTemplateCommond(templateId));
            return Ok();
        }
    }
}
