using BuyMe.Application.Branch.Commonds.CreatEditBranch;
using BuyMe.Application.Branch.Commonds.DeleteBranch;
using BuyMe.Application.Branch.Queries;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Currency.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Config.Controllers
{
    [Authorize(Roles = ApplicationRoles.Branch)]
    public class BranchController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result = await Mediator.Send(new GetBranchesQuery() { DM = new DataManager(dm.Take,dm.Skip,dm.Search?.FirstOrDefault()?.Key) });
            return Json(result);
        }
        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<CreatEditBranchCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.CurrencyId = await Mediator.Send(value.Value);
            return Json(value.Value);

        }
        public async Task<ActionResult> Delete([FromBody] CRUDModel<BranchDto> value)
        {
            _ = await Mediator.Send(new DeleteBranchCommond() { BranchId = Convert.ToInt32(value.Key) });
            return Json(value);
        }
        public async Task< IActionResult> EditAddPartial([FromBody] CRUDModel<CreatEditBranchCommond> value)
        {
            var currencies = await Mediator.Send(new GetCurrenciesQuery());
            ViewBag.currencies = currencies.result;
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
}
