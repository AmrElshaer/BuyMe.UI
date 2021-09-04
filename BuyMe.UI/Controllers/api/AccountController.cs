using BuyMe.Application.Marketing.User.Commonds.Login;
using BuyMe.Application.Marketing.User.Commonds.Register;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BuyMe.UI.Controllers.api
{
    public class AccountController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommond registerCommond)
        {
            await Mediator.Send(registerCommond);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommond loginCommond)
        {
            var token = await Mediator.Send(loginCommond);
            return Ok(new { Token = token });
        }
    }
}