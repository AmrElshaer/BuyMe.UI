using BuyMe.Application.Company.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.UI.Controllers.api
{
    public class CompanyController : BaseController
    {
        [HttpGet]
        public async Task< IActionResult> GetCompany(string name)
        {
            var company =await Mediator.Send(new GetCompanyByNameQuery(name));
            return Ok(company);
        }
    }
}
