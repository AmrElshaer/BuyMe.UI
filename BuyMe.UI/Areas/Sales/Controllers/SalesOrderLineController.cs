using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Product.Queries;
using BuyMe.Application.SalesOrderLine.Commonds;
using BuyMe.Application.SalesOrderLine.Commonds.DeleteSOLine;
using BuyMe.Application.SalesOrderLine.Queries;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Sales.Controllers
{
    public class SalesOrderLineController : BaseController
    {
        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm, long salesOrderId)
        {
            var result = await Mediator.Send(new GetSOLinesQuery(salesOrderId) { DM = new DataManager(dm.Take, dm.Skip, dm.Search?.FirstOrDefault()?.Key) });
            return Json(result);
        }

        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<CreatEditSOLineCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.SalesOrderLineId = await Mediator.Send(value.Value);
            return Json(value.Value);
        }

        public async Task<ActionResult> Delete([FromBody] CRUDModel<SalesOrderLineDto> value)
        {
            _ = await Mediator.Send(new DeleteSOLineCommond() { SalesOrderLineId = int.Parse(value.Key.ToString()) });
            return Json(value);
        }

        public async Task<IActionResult> EditAddPartial([FromBody] CRUDModel<CreatEditSOLineCommond> value)
        {
            ViewBag.Products = (await Mediator.Send(new GetProductQuery())).result;
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
}