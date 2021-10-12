using BuyMe.Application.CartItem.Commonds;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BuyMe.UI.Controllers.api
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CartController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Upsert(CreateEditCartItemCommond command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }
    }
}