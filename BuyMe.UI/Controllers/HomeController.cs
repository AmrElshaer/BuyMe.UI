using BuyMe.Application.Category.Queries;
using BuyMe.Application.Common.Models;
using BuyMe.Application.CustomerType.Queries;
using BuyMe.Application.Invoice.Queries;
using BuyMe.Application.PaymentReceive.Queries;
using BuyMe.Application.SalesOrder.Queries;
using BuyMe.Application.Shipment.Queries;
using BuyMe.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly TenantSettings option;
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(string tenant)
        {
            
            if (!string.IsNullOrEmpty(tenant))
            {
                var tenantDto=await this.mediator.Send(new GetTenantByNameQuery(){TenantName=tenant});
                if (tenantDto==null)
                {
                    return NotFound();
                }
                HttpContext.Response.Cookies.Append("tenant", tenant);
                return RedirectToAction(nameof(Dashboard));
            }
            return LocalRedirect("/Identity/Account/ByMe");
        }
        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            ViewBag.ProductChart = await this.mediator.Send(new GetCategoryChartQuery());
            ViewBag.CustomerChart = await this.mediator.Send(new GetCustomerChartQuery());
            ViewBag.SalesCycle =await SalesCycle();
            return View();
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
            return  (count / 4) * 100;
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
}