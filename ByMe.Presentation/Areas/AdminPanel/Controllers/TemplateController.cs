using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Template.Commonds.CreatEditTemplate;
using BuyMe.Application.Template.Commonds.DeleteTemplate;
using BuyMe.Application.Template.Queries;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ByMe.Presentation.Areas.AdminPanel.Controllers
{
    public class TemplateController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            var result = await Mediator.Send(new GetTemplatesQueries() { DM = new DataManager(dm.Take, dm.Skip, dm.Search?.FirstOrDefault()?.Key) });
            return Json(result);
        }

        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<CreatEditTemplateCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            value.Value.Id = await Mediator.Send(value.Value);
            return Json(value.Value);
        }

        public async Task<ActionResult> Delete([FromBody] CRUDModel<TemplateDto> value)
        {
            _ = await Mediator.Send(new DeleteTemplateCommond() { TemplateId = Convert.ToInt32(value.Key) });
            return Json(value);
        }

        public async Task<IActionResult> EditAddPartial([FromBody] CRUDModel<CreatEditTemplateCommond> value)

        {
            if (value.Value.Id != null)
                ViewBag.TemplateImages = (await Mediator.Send(new GetTemplateImagesQueries(value.Value.Id.Value)));
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
}