﻿using BuyMe.Application.Category.Commonds;
using BuyMe.Application.Category.Commonds.DeleteCategory;
using BuyMe.Application.Category.Queries;
using BuyMe.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Inventory.Controllers
{
    public class CategoryController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result = await Mediator.Send(new GetCategoriesQuery() { DM = dm });
            return Json(result);
        }
        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<CreateEditCategoryCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.CategoryId = await Mediator.Send(value.Value);
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