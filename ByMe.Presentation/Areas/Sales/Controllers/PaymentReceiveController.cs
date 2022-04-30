using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Invoice.Queries;
using BuyMe.Application.PaymentReceive.Commonds.CreatEditPaymentReceive;
using BuyMe.Application.PaymentReceive.Commonds.DeletPaymentReceive;
using BuyMe.Application.PaymentReceive.Queries;
using BuyMe.Application.PaymentType.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ByMe.Presentation.Areas.Sales.Controllers
{
    [Authorize(Roles = ApplicationRoles.PaymentReceive)]
    public class PaymentReceiveController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result = await Mediator.Send(new GetAllPaymentReceiveQuery() { DM = new DataManager(dm.Take, dm.Skip, dm.Search?.FirstOrDefault()?.Key) });
            return Json(result);
        }

        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<CreatEditPaymentReceiveCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.PaymentReceiveId = await Mediator.Send(value.Value);
            return Json(value.Value);
        }

        public async Task<ActionResult> Delete([FromBody] CRUDModel<PaymentReceiveDto> value)
        {
            _ = await Mediator.Send(new DeletPaymentReceiveCommond() { PaymentReceiveId = Convert.ToInt32(value.Key) });
            return Json(value);
        }

        public async Task<IActionResult> EditAddPartial([FromBody] CRUDModel<CreatEditPaymentReceiveCommond> value)
        {
            ViewBag.Invoices = (await Mediator.Send(new GetAllInvoicesQuery()))?.result;
            ViewBag.PaymentTypes = (await Mediator.Send(new GetAllPaymentTypeQuery()))?.result;
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
}
