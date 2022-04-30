using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.SalesType.Commonds.CreateEdit;
using BuyMe.Application.SalesType.Commonds.Delete;
using BuyMe.Application.SalesType.Queries;
using BuyMe.Application.ShipmentType.Commonds.CreateEdit;
using BuyMe.Application.ShipmentType.Commonds.Delete;
using BuyMe.Application.ShipmentType.Queries;
using BuyMe.Application.TenantSetting.Commonds.UpSertTenant;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe.Presentation.Areas.Sales.Controllers
{
    [Authorize(Roles = ApplicationRoles.ShipmentType)]
    public class ShipmentTypeController:BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result = await Mediator.Send(new GetShipmentTypeQuery() { DM = new DataManager(dm.Take, dm.Skip, dm.Search?.FirstOrDefault()?.Key) });
            return Json(result);
        }

        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<CreatEditShipmentTypeCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.Id = await Mediator.Send(value.Value);
            return Json(value.Value);
        }

        public async Task<ActionResult> Delete([FromBody] CRUDModel<ShipmentTypeDto> value)
        {
            _ = await Mediator.Send(new DeleteShipmentTypeCommond() { ShipmentTypeId = Convert.ToInt32(value.Key) });
            return Json(value);
        }

        public IActionResult EditAddPartial([FromBody] CRUDModel<CreatEditShipmentTypeCommond> value)
        {
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
}
