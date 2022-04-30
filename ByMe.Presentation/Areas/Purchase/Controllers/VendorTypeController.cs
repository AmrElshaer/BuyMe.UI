using BuyMe.Application.Category.Commonds.DeleteCategory;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.VendorType.Commonds.CreatEdit;
using BuyMe.Application.VendorType.Commonds.Delete;
using BuyMe.Application.VendorType.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ByMe.Presentation.Areas.Purchase.Controllers
{
    [Authorize(Roles = ApplicationRoles.VendorType)]
    public class VendorTypeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result = await Mediator.Send(new GetVendorTypesQuery() { DM = new DataManager(dm.Take, dm.Skip, dm.Search?.FirstOrDefault()?.Key) });
            return Json(result);
        }

        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<CreatEditVendtorTypeCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.Id = await Mediator.Send(value.Value);
            return Json(value.Value);
        }

        public async Task<ActionResult> Delete([FromBody] CRUDModel<VendorTypeDto> value)
        {
            _ = await Mediator.Send(new DeletVendorTypeCommond() { VendorTypeId = Convert.ToInt32(value.Key) });
            return Json(value);
        }

        public IActionResult EditAddPartial([FromBody] CRUDModel<CreatEditVendtorTypeCommond> value)
        {
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
}
