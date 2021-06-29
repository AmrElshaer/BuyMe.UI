using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Company.Commonds;
using BuyMe.Application.Company.Commonds.DeleteCompany;
using BuyMe.Application.Company.Queries;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.AdminPanel.Controllers
{
    
    public class CompanyController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task< IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result =await Mediator.Send(new GetCompaniesQuery() { DM=new DataManager(dm.Take,dm.Skip,dm.Search?.FirstOrDefault()?.Key)});
            return Json(result);
        }
        public async Task< ActionResult> CreateEdit([FromBody] CRUDModel<CreateEditCompanyCommond> value)
        {
            _= value ?? throw new BadRequestException("Invalid Data");
            value.Value.Id = await Mediator.Send(value.Value);
            return Json(value.Value);

        }
        public async Task<ActionResult> Delete([FromBody] CRUDModel<CompanyDto> value)
        {
            _=await Mediator.Send(new DeleteCompanyCommond() { CompanyId = Convert.ToInt32(value.Key) });
            return Json(value);
        }
        public IActionResult EditAddPartial([FromBody] CRUDModel<CreateEditCompanyCommond> value)
        {
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
    

}
