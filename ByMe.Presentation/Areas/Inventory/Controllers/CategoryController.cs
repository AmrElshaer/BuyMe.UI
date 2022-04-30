using BuyMe.Application.Category.Commonds;
using BuyMe.Application.Category.Commonds.DeleteCategory;
using BuyMe.Application.Category.Queries;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ByMe.Presentation.Areas.Inventory.Controllers
{
    [Authorize(Roles = ApplicationRoles.Category)]
    public class CategoryController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result = await Mediator.Send(new GetCategoriesQuery() { DM = new DataManager(dm.Take, dm.Skip, dm.Search?.FirstOrDefault()?.Key) });
            return Json(result);
        }

        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<CreateEditCategoryCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.CategoryId = await Mediator.Send(value.Value);
            value.Value.RefreshDescriptionCategorys();
            return Json(value.Value);
        }

        public async Task<ActionResult> Delete([FromBody] CRUDModel<CategoryDto> value)
        {
            _ = await Mediator.Send(new DeleteCategoryCommond() { CategoryId = Convert.ToInt32(value.Key) });
            return Json(value);
        }

        public IActionResult EditAddPartial([FromBody] CRUDModel<CreateEditCategoryCommond> value)
        {
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
}