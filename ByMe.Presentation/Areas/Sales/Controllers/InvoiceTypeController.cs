using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Customer.Commonds.CreatEditCustomer;
using BuyMe.Application.Customer.Commonds.DeleteCustomer;
using BuyMe.Application.Customer.Queries.GetCustomers;
using BuyMe.Application.CustomerType.Queries;
using BuyMe.Application.InvoiceType.Commonds.CreatEditIInvoiceType;
using BuyMe.Application.InvoiceType.Commonds.DeletInvoiceType;
using BuyMe.Application.InvoiceType.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ByMe.Presentation.Areas.Sales.Controllers
{
    [Authorize(Roles = ApplicationRoles.InvoiceType)]
    public class InvoiceTypeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result = await Mediator.Send(new GetAllInvoiceTypeQueries() { DM = new DataManager(dm.Take, dm.Skip, dm.Search?.FirstOrDefault()?.Key) });
            return Json(result);
        }

        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<CreatEditInvoiceTypeCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.InvoiceTypeId = await Mediator.Send(value.Value);
            return Json(value.Value);
        }

        public async Task<ActionResult> Delete([FromBody] CRUDModel<InvoiceTypeDto> value)
        {
            _ = await Mediator.Send(new DeleteInvoiceTypeCommond() { InvoiceTypeId = Convert.ToInt32(value.Key) });
            return Json(value);
        }

        public  IActionResult EditAddPartial([FromBody] CRUDModel<CreatEditInvoiceTypeCommond> value)
        {
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
}
