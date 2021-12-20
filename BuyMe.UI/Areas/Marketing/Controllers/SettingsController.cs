using BuyMe.Application.Common.Interfaces;
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
        private readonly ICurrentUserService currentUserService;

        public SettingsController(IOptions<MarketingSettings> options, ICurrentUserService currentUserService)
        {
            _options = options.Value;
            this.currentUserService = currentUserService;
        }

        public async Task<IActionResult> Index()
        {
            var company = await Mediator.Send(new GetCompanyQuery(currentUserService.CompanyId));
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