using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Role.Commonds;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.UserRole.Controllers
{
    public class ChangeRoleController : BaseController
    {
        private readonly ICurrentUserService currentUserService;

        public ChangeRoleController(ICurrentUserService currentUserService)
        {
            this.currentUserService = currentUserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> CreateEdit([FromBody] CRUDModel<UpSertUserRoleCommond> value)
        {
            _ = value ?? throw new BadRequestException("Invalid Data");
            await Mediator.Send(value.Value);
            return Json(value.Value);
        }

        public IActionResult EditAddPartial([FromBody] CRUDModel<UpSertUserRoleCommond> value)
        {
            return PartialView("_CreateEditPartial", value.Value);
        }
    }
}