using BuyMe.Application.Branch.Queries;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.CustomerType.Queries;
using BuyMe.Application.MarketingDefaultSetting.Commonds;
using BuyMe.Application.MarketingDefaultSetting.Queries;
using BuyMe.Application.SalesType.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Marketing.Controllers
{
    public class DefaultMarketingSettingController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            var defaultSetting = await Mediator.Send(new GetDefaultMarkSettingQuery());
            ViewBag.Branches = (await Mediator.Send(new GetBranchesQuery())).result;
            ViewBag.SalesTypes = (await Mediator.Send(new GetSalesTypeQuery())).result;
            ViewBag.CustomerTypes = (await Mediator.Send(new GetCustomersTypeQuery())).result;
            return View(defaultSetting);
        }

        public async Task<ActionResult> CreateEdit(CreateEditMakDefSett value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Id = await Mediator.Send(value);
            return Json(value.Id);
        }
    }
}