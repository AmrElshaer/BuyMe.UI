using BuyMe.Application.Company.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BuyMe.UI.Controllers.api
{
    public class CompanyController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetCompany(string name)
        {
            var company = await Mediator.Send(new GetCompanyByNameQuery(name));
            return Ok(company);
        }
    }
}