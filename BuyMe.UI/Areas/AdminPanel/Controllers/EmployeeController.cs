using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Employee.Commonds.CreateEdit;
using BuyMe.Application.Employee.Commonds.DeleteEmployee;
using BuyMe.Application.Employee.Queries;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.AdminPanel.Controllers
{
    public class EmployeeController : BaseController
    {
        public IActionResult Index(int? companyId)
        {
            ViewBag.CompanyId = companyId ?? throw new NotFoundException("Company", "CompanyId");
            return View();
        }

        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm, int companyId)
        {
            var result = await Mediator.Send(new GetEmployeesQuery()
            {
                DM = new DataManager(dm.Take, dm.Skip, dm.Search?.FirstOrDefault()?.Key)
                ,
                CompanyId = companyId
            });
            return Json(result);
        }

        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<CreatEditEmployeeCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.Id = await Mediator.Send(value.Value);
            return Json(value.Value);
        }

        public async Task<ActionResult> Delete([FromBody] CRUDModel<EmployeeDto> value)
        {
            _ = await Mediator.Send(new DeleteEmployeeCommond() { EmployeeId = Convert.ToInt32(value.Key) });
            return Json(value);
        }

        public IActionResult EditAddPartial([FromBody] CRUDModel<CreatEditEmployeeCommond> value)
        {
            value.Value.ConfirmPassword = value.Value.Password;
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
}