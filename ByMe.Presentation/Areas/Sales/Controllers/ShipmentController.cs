using BuyMe.Application.Branch.Queries;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Customer.Queries.GetCustomers;
using BuyMe.Application.SalesOrder.Commonds.DeleteSalesOrder;
using BuyMe.Application.SalesOrder.Commonds;
using BuyMe.Application.SalesOrder.Queries;
using BuyMe.Application.SalesOrderLine.Queries;
using BuyMe.Application.SalesType.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyMe.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using BuyMe.Application.Shipment.Queries;
using BuyMe.Application.Shipment.Commonds;
using BuyMe.Application.WarehouseINV.Queries;
using BuyMe.Application.ShipmentType.Queries;

namespace ByMe.Presentation.Areas.Sales.Controllers
{
    [Authorize(Roles = ApplicationRoles.Shipment)]
    public class ShipmentController:BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result = await Mediator.Send(new GetShipmentsQuery() { DM = new DataManager(dm.Take, dm.Skip, dm.Search?.FirstOrDefault()?.Key) });
            return Json(result);
        }

        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<CreateEditShipCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.ShipmentId = await Mediator.Send(value.Value);
            return Json(value.Value);
        }

        public async Task<ActionResult> GetById(long id)
        {
            var so = await Mediator.Send(new GetSalesOrderQuery(id));
            return Json(so);
        }

        public async Task<ActionResult> Delete([FromBody] CRUDModel<ShipmentDto> value)
        {
            _ = await Mediator.Send(new DeleteShipCommond() { ShipmentId = long.Parse(value.Key.ToString()) });
            return Json(value);
        }

        public async Task<IActionResult> EditAddPartial([FromBody] CRUDModel<CreateEditShipCommond> value)
        {
            ViewBag.Warhouses = (await Mediator.Send(new GetWarehousesQuery())).result;
            ViewBag.SalesOrders = (await Mediator.Send(new GetSalesOrdersQuery())).result;
            ViewBag.ShipmentTypes = (await Mediator.Send(new GetShipmentTypeQuery())).result;
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
}
