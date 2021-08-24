using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.UnitOfMeasure.Commonds;
using BuyMe.Application.UnitOfMeasure.Commonds.DeleteUnitOfMeasure;
using BuyMe.Application.UnitOfMeasure.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Inventory.Controllers
{
    [Authorize(Roles = ApplicationRoles.UnitOfMeasure)]
    public class UOMController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result = await Mediator.Send(new GetUOMQuery() { DM = new DataManager(dm.Take, dm.Skip, dm.Search?.FirstOrDefault()?.Key) });
            return Json(result);
        }
        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<CreateEditUnitOfMeasureCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.Id = await Mediator.Send(value.Value);
            return Json(value.Value);

        }
        public async Task<ActionResult> Delete([FromBody] CRUDModel<UnitOfMeasureDto> value)
        {
            _ = await Mediator.Send(new DeleteUnitOfMeasureCommond() { UOMId = Convert.ToInt32(value.Key) });
            return Json(value);
        }
        public IActionResult EditAddPartial([FromBody] CRUDModel<CreateEditUnitOfMeasureCommond> value)
        {
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
}
