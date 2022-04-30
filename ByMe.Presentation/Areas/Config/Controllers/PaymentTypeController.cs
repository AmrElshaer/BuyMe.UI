using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.PaymentType.Commonds.CreatEditCommond;
using BuyMe.Application.PaymentType.Commonds.DeletCommond;
using BuyMe.Application.PaymentType.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ByMe.Presentation.Areas.Config.Controllers
{
    [Authorize(Roles = ApplicationRoles.PaymentType)]
    public class PaymentTypeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result = await Mediator.Send(new GetAllPaymentTypeQuery() { DM = new DataManager(dm.Take, dm.Skip, dm.Search?.FirstOrDefault()?.Key) });
            return Json(result);
        }

        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<CreatEditPaymentTypeCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.PaymentTypeId = await Mediator.Send(value.Value);
            return Json(value.Value);
        }

        public async Task<ActionResult> Delete([FromBody] CRUDModel<PaymentTypeDto> value)
        {
            _ = await Mediator.Send(new DeletePaymentTypeCommond() { PaymentTypeId = Convert.ToInt32(value.Key) });
            return Json(value);
        }

        public IActionResult EditAddPartial([FromBody] CRUDModel<CreatEditPaymentTypeCommond> value)
        {
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
}
