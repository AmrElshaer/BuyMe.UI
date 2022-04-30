using BuyMe.Application.Customer.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe.Presentation.Controllers.api
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CustomerController:BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetCustomer(int customerId)
        {
            var customer = await Mediator.Send(new GetCustomerByIdQuery(customerId));
            return Ok(customer);
        }
    }
}
