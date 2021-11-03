using BuyMe.Application.CartItem.Commonds;
using BuyMe.Application.CartItem.Queries;
using BuyMe.Application.Customer.Commonds.CreatEditCustomer;
using BuyMe.Application.SalesOrder.Commonds;
using BuyMe.Application.SalesOrderLine.Commonds;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BuyMe.UI.Controllers.api
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrderController : BaseController
    {
        public async Task<IActionResult> CheckOut(CreatEditCustomerCommond customerCommond)
        {
            await Mediator.Send(customerCommond);
            var cartItems = await Mediator.Send(new GetCartItemsByCustomerIdQuery(customerCommond.Id.Value));
            var salesOrderId = await Mediator.Send(new CreateEditSOCommond() { CustomerId = customerCommond.Id });
            foreach (var item in cartItems)
            {
                await Mediator.Send(new CreatEditSOLineCommond()
                {
                    SalesOrderId = (int)salesOrderId,
                    ProductId = item.ProductId,
                    Quantity = item.QTN,
                });
            }
            foreach (var item in cartItems)
            {
                await Mediator.Send(new DeleteCartItemCommond(item.Id));
            }
            return Ok(salesOrderId);
        }
    }
}