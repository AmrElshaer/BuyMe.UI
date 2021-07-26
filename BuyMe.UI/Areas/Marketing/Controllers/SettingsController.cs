using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Company.Commonds;
using BuyMe.Application.Company.Queries;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Marketing.Controllers
{
    public class SettingsController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            var company =await Mediator.Send(new GetCompanyQuery());
            return View(company);
        }
        [HttpPost]
        public async Task<ActionResult> EditCompany(CreateEditCompanyCommond value)
        {
            
                await Mediator.Send(value);
                return Ok();

        }
    }
}
