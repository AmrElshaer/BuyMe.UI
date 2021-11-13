using BuyMe.Application.CartItem.Commonds;
using BuyMe.Application.CartItem.Queries;
using BuyMe.Application.Customer.Commonds.CreatEditCustomer;
using BuyMe.Application.MarketingDefaultSetting.Queries;
using BuyMe.Application.SalesOrder.Commonds;
using BuyMe.Application.SalesOrder.Queries;
using BuyMe.Application.SalesOrderLine.Commonds;
using BuyMe.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyMe.UI.Controllers.api
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrderController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CheckOut(CreatEditCustomerCommond customerCommond)
        {
            // update user profile
            await UpdateCustomerInfo(customerCommond);
            // create order
            long salesOrderId = await CreateOrder(customerCommond);
            // create sales orderline
            await CreateSalesOrderLines(customerCommond.Id.Value, salesOrderId);
            // remove all cartItems
            await DeleteCartItems(customerCommond.Id.Value);

            return Ok(salesOrderId);
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomerOrders(int customerId)
        {
             return Ok( await Mediator.Send(new GetCustomerOrdersQuery(customerId)));

        }

        #region CheckOut Helper Methods
        private async Task UpdateCustomerInfo(CreatEditCustomerCommond customerCommond)
        {
            var defaultSetting = await Mediator.Send(new GetDefaultMarkSettingQuery());
            customerCommond.CustomerTypeId = defaultSetting.CustomerTypeId;
            await Mediator.Send(customerCommond);
        }

        private async Task DeleteCartItems(int customerId)
        {
            var cartItems = await Mediator.Send(new GetCartItemsByCustomerIdQuery(customerId));
            foreach (var item in cartItems)
            {
                await Mediator.Send(new DeleteCartItemCommond(item.Id));
            }
        }

        private async Task CreateSalesOrderLines(int customerId, long salesOrderId)
        {
            var cartItems = await Mediator.Send(new GetCartItemsByCustomerIdQuery(customerId));
            foreach (var item in cartItems)
            {
                await Mediator.Send(new CreatEditSOLineCommond()
                {
                    SalesOrderId = (int)salesOrderId,
                    ProductId = item.ProductId,
                    Quantity = item.QTN,
                    Price = (double)item.Product.DefaultSellingPrice

                });
            }
        }

        private async Task<long> CreateOrder(CreatEditCustomerCommond customerCommond)
        {
            var defaultSetting = await Mediator.Send(new GetDefaultMarkSettingQuery());
            var upSertOrder = new CreateEditSOCommond();
            upSertOrder.CustomerId = customerCommond.Id;
            upSertOrder.CurrencyId = defaultSetting?.CurrencyId;
            upSertOrder.OrderDate = System.DateTime.Now;
            upSertOrder.BranchId = defaultSetting?.BranchId;
            upSertOrder.SalesTypeId = defaultSetting?.SalesTypeId;
            upSertOrder.CurrencyCode = defaultSetting?.Currency?.CurrencyCode;
            var salesOrderId = await Mediator.Send(upSertOrder);
            return salesOrderId;
        } 
        #endregion


    }
}