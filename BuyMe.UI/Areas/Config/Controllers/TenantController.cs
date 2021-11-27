using BuyMe.Application.TenantSetting.Commonds.UpSertTenant;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Config.Controllers
{
    public class TenantController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpSertTenant(UpSertTenantCommond upSertTenant)
        {
            var tenant = await Mediator.Send(upSertTenant);
            return Ok(tenant);
        }
    }
}
