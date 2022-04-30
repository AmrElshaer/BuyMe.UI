using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.CustomerType.Queries;
using BuyMe.Application.Vendor.Commonds.CreatEdit;
using BuyMe.Application.Vendor.Commonds.Delete;
using BuyMe.Application.Vendor.Queries;
using BuyMe.Application.VendorType.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe.Presentation.Areas.Purchase.Controllers
{
    [Authorize(Roles = ApplicationRoles.Vendor)]
    public class VendorController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result = await Mediator.Send(new GetVendorsQuery() { DM = new DataManager(dm.Take, dm.Skip, dm.Search?.FirstOrDefault()?.Key) });
            return Json(result);
        }

        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<CreatEditVendorCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.Id = await Mediator.Send(value.Value);
            return Json(value.Value);
        }

        public async Task<ActionResult> Delete([FromBody] CRUDModel<VendorDto> value)
        {
            _ = await Mediator.Send(new DeletVendorCommond() { VendorId = Convert.ToInt32(value.Key) });
            return Json(value);
        }

        public async Task<IActionResult> EditAddPartialAsync([FromBody] CRUDModel<CreatEditVendorCommond> value)
        {
            ViewBag.VendorTypes = (await Mediator.Send(new GetVendorTypesQuery()))?.result;
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
}
