using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Company.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BuyMe.UI.Controllers.api
{
    public class ManifestController : BaseController
    {
        private readonly IGenerateManifestService generateManifest;

        public ManifestController(IGenerateManifestService generateManifest)
        {
            this.generateManifest = generateManifest;
        }

        [HttpGet]
        public async Task<IActionResult> GetManifest(string company)
        {
            return new JsonResult(generateManifest.GenerateManifest(
                await Mediator.Send(new GetCompanyByNameQuery(company))
                ));
        }
    }
}