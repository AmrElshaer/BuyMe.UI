using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Employee.Commonds.CreateEdit;
using BuyMe.Application.Employee.Commonds.DeleteEmployee;
using BuyMe.Application.Employee.Queries;
using BuyMe.Application.Role.Commonds;
using BuyMe.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.UserRole.Controllers
{
    public class ChangeRoleController:BaseController
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
