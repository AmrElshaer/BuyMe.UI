using BuyMe.Application.Branch.Queries;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.WarehouseINV.Commonds.CreatEdit;
using BuyMe.Application.WarehouseINV.Commonds.DeleteWarehouse;
using BuyMe.Application.WarehouseINV.Queries;
using BuyMe.UI.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Inventory.Controllers
{
    [Authorize(Roles =ApplicationRoles.Warehouse)]
    public class WarehouseController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result = await Mediator.Send(new GetWarehousesQuery() { DM = new DataManager(dm.Take, dm.Skip, dm.Search?.FirstOrDefault()?.Key) });
            return Json(result);
        }
        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<CreatEditWarehouseCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.WarehouseId = await Mediator.Send(value.Value);
            return Json(value.Value);

        }
        public async Task<ActionResult> Delete([FromBody] CRUDModel<WarhouseDto> value)
        {
            _ = await Mediator.Send(new DeleteWarehouseCommond() { WarehouseId = Convert.ToInt32(value.Key) });
            return Json(value);
        }
        public async Task<IActionResult> EditAddPartial([FromBody] CRUDModel<CreatEditWarehouseCommond> value)
        {
            ViewBag.Branches = (await Mediator.Send(new GetBranchesQuery()))?.result;
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
}
