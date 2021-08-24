using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Customer.Commonds.CreatEditCustomer;
using BuyMe.Application.Customer.Commonds.DeleteCustomer;
using BuyMe.Application.Customer.Queries.GetCustomers;
using BuyMe.Application.CustomerType.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Sales.Controllers
{
    [Authorize(Roles = ApplicationRoles.Customer)]
    public class CustomerController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result = await Mediator.Send(new GetCustomersQurery() { DM = new DataManager(dm.Take, dm.Skip, dm.Search?.FirstOrDefault()?.Key) });
            return Json(result);
        }
        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<CreatEditCustomerCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.CustomerTypeId = await Mediator.Send(value.Value);
            return Json(value.Value);

        }
        public async Task<ActionResult> Delete([FromBody] CRUDModel<CustomerDto> value)
        {
            _ = await Mediator.Send(new DeleteCustomerCommond() { CustomerId = Convert.ToInt32(value.Key) });
            return Json(value);
        }
        public async Task<IActionResult> EditAddPartial([FromBody] CRUDModel<CreatEditCustomerCommond> value)
        {
            ViewBag.CustomerTypes = (await Mediator.Send(new GetCustomersTypeQuery()))?.result;
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
}
