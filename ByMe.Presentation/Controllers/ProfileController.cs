using BuyMe.Application.User.Commonds.ChangePassword;
using BuyMe.Application.User.Commonds.UpdateProfilePhoto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ByMe.Presentation.Controllers
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
        [HttpPost]
        public async Task<IActionResult> SaveProfileImage(UpdateProfilePhotoCommond commond)
        {
            await Mediator.Send(commond);
            return Ok();
        }
    }
}
