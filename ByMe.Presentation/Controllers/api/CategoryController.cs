using BuyMe.Application.Category.Queries;
using BuyMe.Application.Company.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ByMe.Presentation.Controllers.api
{
    public class CategoryController:BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetCategories(string companyName)
{
            var result=await  Mediator.Send(new GetCategoriesWithProductQuery(companyName));
            return Ok(result);
        }
    }
}
