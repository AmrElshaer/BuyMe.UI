using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.SalesType.Commonds.CreateEdit;
using BuyMe.Application.SalesType.Commonds.Delete;
using BuyMe.Application.SalesType.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Sales.Controllers
{
    [Authorize(Roles = ApplicationRoles.SalesType)]
    public class SalesTypeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result = await Mediator.Send(new GetSalesTypeQuery() { DM = new DataManager(dm.Take, dm.Skip, dm.Search?.FirstOrDefault()?.Key) });
            return Json(result);
        }

        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<CreatEditSalesTypeCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.SalesTypeId = await Mediator.Send(value.Value);
            return Json(value.Value);
        }

        public async Task<ActionResult> Delete([FromBody] CRUDModel<SalesTypeDto> value)
        {
            _ = await Mediator.Send(new DeleteSalesTypeCommond() { SalesTypeId = Convert.ToInt32(value.Key) });
            return Json(value);
        }

        public IActionResult EditAddPartial([FromBody] CRUDModel<CreatEditSalesTypeCommond> value)
        {
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
}