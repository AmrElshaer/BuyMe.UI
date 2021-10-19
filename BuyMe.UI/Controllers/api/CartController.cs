using BuyMe.Application.CartItem.Commonds;
using BuyMe.Application.CartItem.Queries;
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
        [HttpGet]
        public async Task<IActionResult> GetAll(int customerId)
        {
            var cartItems = await Mediator.Send(new GetCartItemsByCustomerIdQuery(customerId));
            return Ok(cartItems);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCartItem(int cartItemId)
        {
            await Mediator.Send(new DeleteCartItemCommond(cartItemId));
            return Ok();
        }
    }
}