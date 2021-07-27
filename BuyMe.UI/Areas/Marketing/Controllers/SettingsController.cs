using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Company.Commonds;
using BuyMe.Application.Company.Queries;
using BuyMe.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Marketing.Controllers
{
public class SettingsController : BaseController
{
        private readonly MarketingSettings _options;
        public SettingsController(IOptions<MarketingSettings> options)
        {
            _options = options.Value;
        }
        public async Task<IActionResult> Index()
        {
            var company =await Mediator.Send(new GetCompanyQuery());
            ViewBag.MarketingLink = $"{_options.Domain}{company.Name}";
            return View(company);
        }
        [HttpPost]
        public async Task<ActionResult> EditCompany(CreateEditCompanyCommond value)
        {
            
                await Mediator.Send(value);
                return Ok();

        }
    }
}
