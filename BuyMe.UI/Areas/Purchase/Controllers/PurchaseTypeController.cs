using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.PurchaseType.Commonds.CreatEdit;
using BuyMe.Application.PurchaseType.Commonds.Delete;
using BuyMe.Application.PurchaseType.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Purchase.Controllers
{
    [Authorize(Roles = ApplicationRoles.PurchaseType)]
    public class PurchaseTypeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result = await Mediator.Send(new GetPurchaseTypesQuery() { DM = new DataManager(dm.Take, dm.Skip, dm.Search?.FirstOrDefault()?.Key) });
            return Json(result);
        }

        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<CreatEditPurchaseTypeCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.Id = await Mediator.Send(value.Value);
            return Json(value.Value);
        }

        public async Task<ActionResult> Delete([FromBody] CRUDModel<PurchaseTypeDto> value)
        {
            _ = await Mediator.Send(new DeletPurchaseTypeCommond() { PurchaseTypeId = Convert.ToInt32(value.Key) });
            return Json(value);
        }

        public IActionResult EditAddPartial([FromBody] CRUDModel<CreatEditPurchaseTypeCommond> value)
        {
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
}
