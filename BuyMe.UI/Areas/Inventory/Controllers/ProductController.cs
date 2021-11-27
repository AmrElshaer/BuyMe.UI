using BuyMe.Application.Branch.Queries;
using BuyMe.Application.Category.Queries;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.CustomField.Queries.GetCustomFields;
using BuyMe.Application.CustomFieldData.Commonds.UpSertCustFieldData;
using BuyMe.Application.Product.Commonds;
using BuyMe.Application.Product.Commonds.DeleteProduct;
using BuyMe.Application.Product.Queries;
using BuyMe.Application.UnitOfMeasure.Queries;
using BuyMe.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Inventory.Controllers
{
    [Authorize(Roles = ApplicationRoles.Product)]
    public class ProductController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.AdditionalColums = await Mediator.Send(new GetCustomFieldQuery() {Category=CustomCategoryModel.Product });
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
            if (value.Value.CustomColumns != null && value.Value.CustomColumns.Any())
            {
                await Mediator.Send(new UpSertCustFieldDataCommond()
                {
                    Category = "Product",
                    CustomColumns = value.Value.CustomColumns,
                    RefranceId = value.Value.ProductId.Value
                });
            }
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
            if (value.Value.CategoryId.HasValue)
            {
                value.Value.ProductDescriptions = await GetProductDesc(value.Value.ProductId, value.Value.CategoryId.Value);
            }

            return PartialView("_CreateEditPartial", value.Value);
        }
        public async Task<IActionResult> GetProductDescription(int? productId, int categoryId)
        {

            return PartialView("_ProductDescription", await GetProductDesc(productId, categoryId));
        }

        private async Task<IList<ProductDescriptionDto>> GetProductDesc(int? productId, int categoryId)
        {
            var categoryDescs = await Mediator.Send(new GetCategoryDescriptionQuery(categoryId));
            var productDescs = productId != null ? (await Mediator.Send(new GetProductDescriptionQuery(productId, categoryId)))
                : new List<ProductDescriptionDto>();
            categoryDescs.ToList().ForEach(item =>
            {
                var catdesc = productDescs.FirstOrDefault(a => a.CategoryDescriptionId == item.Id);
                if (catdesc == null)
                {
                    productDescs.Add(new()
                    {
                        CategoryDescription = item,
                        CategoryDescriptionId = item.Id,
                        ProductId = productId
                    });
                }

            });
            return productDescs;
        }

        public async Task<IActionResult> GetProductPrice(int productId)
        {
            var pro = await Mediator.Send(new GetProducbyIdtQuery(productId));
            return Json(pro);
        }
    }
}