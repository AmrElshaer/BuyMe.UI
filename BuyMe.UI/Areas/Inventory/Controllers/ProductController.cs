using BuyMe.Application.Branch.Queries;
using BuyMe.Application.Category.Queries;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Product.Commonds;
using BuyMe.Application.Product.Commonds.DeleteProduct;
using BuyMe.Application.Product.Queries;
using BuyMe.Application.UnitOfMeasure.Queries;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Inventory.Controllers
{
    public class ProductController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result = await Mediator.Send(new GetProductQuery() { DM = new DataManager(dm.Take, dm.Skip, dm.Search?.FirstOrDefault()?.Key) });
            return Json(result);
        }

        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<CreateEditProductCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.ProductId = await Mediator.Send(value.Value);
            return Json(value.Value);
        }

        public async Task<ActionResult> Delete([FromBody] CRUDModel<ProductDto> value)
        {
            _ = await Mediator.Send(new DeleteProductCommond() { ProductId = Convert.ToInt32(value.Key) });
            return Json(value);
        }

        public async Task<IActionResult> EditAddPartial([FromBody] CRUDModel<CreateEditProductCommond> value)
        {
            ViewBag.UOMS = (await Mediator.Send(new GetUOMQuery()))?.result;
            ViewBag.Categories = (await Mediator.Send(new GetCategoriesQuery()))?.result;
            ViewBag.Branches = (await Mediator.Send(new GetBranchesQuery()))?.result;
            if (value.Value.ProductId != null) ViewBag.ProductImages = (await Mediator.Send(new GetProductImagesQuery(value.Value.ProductId.Value)));
            return PartialView("_CreateEditPartial", value.Value);
        }

        public async Task<IActionResult> GetProductPrice(int productId)
        {
            var pro = await Mediator.Send(new GetProducbyIdtQuery(productId));
            return Json(pro);
        }
    }
}