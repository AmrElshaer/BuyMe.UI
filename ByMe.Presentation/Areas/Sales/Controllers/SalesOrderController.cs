using BuyMe.Application.Branch.Queries;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Customer.Queries.GetCustomers;
using BuyMe.Application.SalesOrder.Commonds;
using BuyMe.Application.SalesOrder.Commonds.DeleteSalesOrder;
using BuyMe.Application.SalesOrder.Queries;
using BuyMe.Application.SalesType.Queries;
using ByMe.Presentation.Helper.PdfDocuments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;


namespace ByMe.Presentation.Areas.Sales.Controllers
{
    [Authorize(Roles = ApplicationRoles.SalesOrder)]
    public class SalesOrderController : BaseController
    {
        private readonly ISalesOrderDocument salesOrderDocument;

        public SalesOrderController(ISalesOrderDocument salesOrderDocument)
        {
            this.salesOrderDocument = salesOrderDocument;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result = await Mediator.Send(new GetSalesOrdersQuery() { DM = new DataManager(dm.Take, dm.Skip, dm.Search?.FirstOrDefault()?.Key) });
            return Json(result);
        }

        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<CreateEditSOCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.SalesOrderId = await Mediator.Send(value.Value);
            return Json(value.Value);
        }

        public async Task<IActionResult> Print(long salesOrderId)
        {

            return File(await salesOrderDocument.GetSalesOrderPDfAsync(salesOrderId), "application/pdf");


        }

        public async Task<ActionResult> Details(long salesOrderId)
        {
            var so = await Mediator.Send(new GetSalesOrderQuery(salesOrderId));
            return View(so);
        }

        public async Task<ActionResult> GetById(long id)
        {
            var so = await Mediator.Send(new GetSalesOrderQuery(id));
            return Json(so);
        }

        public async Task<ActionResult> Delete([FromBody] CRUDModel<SalesOrderDto> value)
        {
            _ = await Mediator.Send(new DeleteSalesOrderCommond() { SalesOrderId = long.Parse(value.Key.ToString()) });
            return Json(value);
        }

        public async Task<IActionResult> EditAddPartial([FromBody] CRUDModel<CreateEditSOCommond> value)
        {
            ViewBag.Customers = (await Mediator.Send(new GetCustomersQurery())).result;
            ViewBag.Branches = (await Mediator.Send(new GetBranchesQuery())).result;
            ViewBag.SalesTypes = (await Mediator.Send(new GetSalesTypeQuery())).result;
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
}