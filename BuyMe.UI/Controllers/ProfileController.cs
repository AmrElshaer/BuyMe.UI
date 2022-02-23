using BuyMe.Application.User.Commonds.ChangePassword;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Controllers
{
    public class ProfileController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommond commond)
        {
            await Mediator.Send(commond);
            return Ok();
        }
    }
}
