using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Company.Commonds.DeleteCompany;
using BuyMe.Application.Company.Commonds;
using BuyMe.Application.Company.Queries;
using BuyMe.Application.TenantSetting.Commonds.UpSertTenant;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyMe.Application.Common.Models;
using BuyMe.Application.TenantSetting.Queries;
using System.Threading;

namespace ByMe.Presentation.Areas.AdminPanel.Controllers
{
    public class TenantController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result = await Mediator.Send(new GetAllTenantQuery() { DM = new DataManager(dm.Take, dm.Skip, dm.Search?.FirstOrDefault()?.Key) });
            return Json(result);
        }

        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<UpSertTenantCommond> value,CancellationToken token)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.Id = await Mediator.Send(value.Value, token);
            return Json(value.Value);
        }

      

        public IActionResult EditAddPartial([FromBody] CRUDModel<UpSertTenantCommond> value)
        {
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
}
