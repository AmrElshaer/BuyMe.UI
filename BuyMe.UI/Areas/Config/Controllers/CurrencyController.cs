using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Currency.Commonds.CreateEditCurrency;
using BuyMe.Application.Currency.Commonds.DeleteCurrency;
using BuyMe.Application.Currency.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Config.Controllers
{
    [Authorize(Roles = ApplicationRoles.Currency)]
    public class CurrencyController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result = await Mediator.Send(new GetCurrenciesQuery() { DM = new DataManager(dm.Take, dm.Skip, dm.Search?.FirstOrDefault()?.Key) });
            return Json(result);
        }

        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<CreatEditCurrencyCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.CurrencyId = await Mediator.Send(value.Value);
            return Json(value.Value);
        }

        public async Task<ActionResult> Delete([FromBody] CRUDModel<CurrencyDto> value)
        {
            _ = await Mediator.Send(new DeleteCurrencyCommond() { CurrencyId = Convert.ToInt32(value.Key) });
            return Json(value);
        }

        public IActionResult EditAddPartial([FromBody] CRUDModel<CreatEditCurrencyCommond> value)
        {
            return PartialView("_CreateEditPartial", value.Value);
        }

        public async Task<IActionResult> GetBranchCurrency(int branchId)
        {
            var currency = await Mediator.Send(new GetBranchCurrencyQuery() { BranchId = branchId });
            return Json(currency);
        }
    }
}