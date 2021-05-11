using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Company.Commonds;
using BuyMe.Application.Company.Commonds.DeleteCompany;
using BuyMe.Application.Company.Queries;
using BuyMe.UI.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CompanyController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task< IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result =await Mediator.Send(new GetCompaniesQuery() { DM=dm});
            return Json(result);
        }
        public async Task< ActionResult> CreateEdit([FromBody] ICRUDModel<CreateEditCommond> value)
        {
            _= value ?? throw new BadRequestException("Invalid Data");
            value.value.Id = await Mediator.Send(value.value);
            return Json(value.value);

        }

        public async Task<ActionResult> Delete([FromBody] ICRUDModel<CompanyDto> value)
        {
            _=await Mediator.Send(new DeleteCompanyCommond() { CompanyId = Convert.ToInt32(value.key) });
            return Json(value);
        }
        public IActionResult EditAddPartial([FromBody] CRUDModel<CreateEditCommond> value)
        {
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
  
}
