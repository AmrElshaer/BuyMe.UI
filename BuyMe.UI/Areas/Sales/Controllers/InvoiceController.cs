using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.CustomerType.Queries;
using BuyMe.Application.Invoice.Commonds.CreatEditInvoice;
using BuyMe.Application.Invoice.Commonds.DeleteInvoice;
using BuyMe.Application.Invoice.Queries;
using BuyMe.Application.InvoiceType.Commonds.CreatEditIInvoiceType;
using BuyMe.Application.InvoiceType.Commonds.DeletInvoiceType;
using BuyMe.Application.InvoiceType.Queries;
using BuyMe.Application.Shipment.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Sales.Controllers
{
    [Authorize(Roles = ApplicationRoles.Invoice)]
    public class InvoiceController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result = await Mediator.Send(new GetAllInvoicesQuery() { DM = new DataManager(dm.Take, dm.Skip, dm.Search?.FirstOrDefault()?.Key) });
            return Json(result);
        }

        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<UpSertInvoiceCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.InvoiceId = await Mediator.Send(value.Value);
            return Json(value.Value);
        }

        public async Task<ActionResult> Delete([FromBody] CRUDModel<InvoiceTypeDto> value)
        {
            _ = await Mediator.Send(new DeleteInvoiceCommond() { InvoiceId = Convert.ToInt32(value.Key) });
            return Json(value);
        }

        public async Task<IActionResult> EditAddPartial([FromBody] CRUDModel<UpSertInvoiceCommond> value)
        {
            ViewBag.InvoiceTypes = (await Mediator.Send(new GetAllInvoiceTypeQueries()))?.result;
            ViewBag.Shipments= (await Mediator.Send(new GetShipmentsQuery()))?.result;
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
}
