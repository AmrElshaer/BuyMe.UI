using BuyMe.Application.Common.Models;
using BuyMe.Application.Company.Commonds;
using BuyMe.Application.Company.Queries;
using BuyMe.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Marketing.Controllers
{
    [Authorize(Roles = ApplicationRoles.Settings)]
    public class SettingsController : BaseController
    {
        private readonly MarketingSettings _options;

        public SettingsController(IOptions<MarketingSettings> options)
        {
            _options = options.Value;
        }

        public async Task<IActionResult> Index()
        {
            var company = await Mediator.Send(new GetCompanyQuery());
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