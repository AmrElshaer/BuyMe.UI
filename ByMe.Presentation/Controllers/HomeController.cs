using BuyMe.Application.Category.Queries;
using BuyMe.Application.CustomerType.Queries;
using BuyMe.Application.Invoice.Queries;
using BuyMe.Application.PaymentReceive.Queries;
using BuyMe.Application.SalesOrder.Queries;
using BuyMe.Application.Shipment.Queries;
using ByMe.Presentation.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ByMe.Presentation.Controllers
{

    public class HomeController : Controller
    {

        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(string tenant)
        {
            if (string.IsNullOrEmpty(tenant)) return LocalRedirect("/Identity/Account/ByMe");
            var tenantDto = await this.mediator.Send(new GetTenantByNameQuery() { TenantName = tenant });
            if (tenantDto == null) return NotFound();
            HttpContext.Response.Cookies.Append("tenant", tenant);
            return RedirectToAction(nameof(Dashboard));


        }

        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            ViewBag.ProductChart = await mediator.Send(new GetCategoryChartQuery());
            ViewBag.CustomerChart = await mediator.Send(new GetCustomerChartQuery());
            ViewBag.SalesCycle = await SalesCycle();
            ViewBag.SalesOrderMonthly = await SalesOrderMonthly();
            ViewBag.InvoicesMonthly = await InvoiceMonthly();
            ViewBag.PaymentsRecMonthly = await PaymentRecMonthly();
            ViewBag.ShipmentsMonthly = await ShipmentMonthly();

            return View();
        }

        private async Task<IEnumerable<CombinationSeriesData>> ShipmentMonthly()
        {
            var shipments = await mediator.Send(new GetShipmentsQuery());
            var shipmentsMonthly = shipments.result.GroupBy(a => a.ShipmentDate.ToString("MMM")).Select(a => new CombinationSeriesData()
            {
                x = a.Key,
                y = (a.Count())
            });
            return shipmentsMonthly;
        }

        private async Task<IEnumerable<CombinationSeriesData>> PaymentRecMonthly()
        {
            var paymentRecs = await mediator.Send(new GetAllPaymentReceiveQuery());
            var paymentRecMonthly = paymentRecs.result.GroupBy(a => a.PaymentDate.ToString("MMM")).Select(a => new CombinationSeriesData()
            {
                x = a.Key,
                y = (a.Count())
            });
            return paymentRecMonthly;
        }

        private async Task<IEnumerable<CombinationSeriesData>> SalesOrderMonthly()
        {
            var salesOrders = await mediator.Send(new GetSalesOrdersQuery());
            var salesOrderMonthly = salesOrders.result.GroupBy(a => a.OrderDate.ToString("MMM")).Select(a => new CombinationSeriesData()
            {
                x = a.Key,
                y = (a.Count())
            });
            return salesOrderMonthly;

        }
        private async Task<IEnumerable<CombinationSeriesData>> InvoiceMonthly()
        {
            var invoices = await mediator.Send(new GetAllInvoicesQuery());
            var invoiceMonthly = invoices.result.GroupBy(a => a.InvoiceDate.ToString("MMM")).Select(a => new CombinationSeriesData()
            {
                x = a.Key,
                y = (a.Count())
            });
            return invoiceMonthly;

        }

        private async Task<IEnumerable<object>> SalesCycle()
        {
            var salesOrders = await mediator.Send(new GetSalesOrdersQuery());
            var invoices = await mediator.Send(new GetAllInvoicesQuery());
            var shipments = await mediator.Send(new GetShipmentsQuery());
            var paymentsRec = await mediator.Send(new GetAllPaymentReceiveQuery());
            var salesCycle = new List<object>();
            salesCycle.AddRange(new List<object>{
                new {xValue="Sales Order", yValue=SalesCyclePercetage(salesOrders.count) },
                new {xValue= "Invoice",yValue=SalesCyclePercetage(invoices.count)},
                new {xValue="Shipment",yValue=SalesCyclePercetage(shipments.count) },
                new {xValue="Payment Receive",yValue=SalesCyclePercetage(paymentsRec.count)}
            });
            return salesCycle;
        }
        private double SalesCyclePercetage(double count)
        {
            return (count / 4) * 100;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public class CombinationSeriesData
    {
        public string x;
        public double y;
    }
}