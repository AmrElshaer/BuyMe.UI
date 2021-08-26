using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Company.Queries;
using BuyMe.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyMe.UI.Controllers.api
{
    public class ManifestController : BaseController
    {
        private readonly MarketingSettings _options;
        private readonly IImageService imageService;

        public ManifestController(IOptions<MarketingSettings> options, IImageService imageService)
        {
            _options = options.Value;
            this.imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetManifest(string company)
        {
            var res = await Mediator.Send(new GetCompanyByNameQuery(company));

            var manifest = new
            {
                name = company,
                short_name = company,
                theme_color = "#1976d2",
                background_color = "#fafafa",
                display = "standalone",
                scope = $"{_options.Domain}/{company}",
                start_url = $"{_options.Domain}/{company}",
                icons = new List<object>() {
                    new{
                        src=imageService.ResizeIfLargerThan(res.Logo,72,72),
                        sizes= "72x72",
                        type= "image/png",
                        purpose= "maskable any"
                    },
                    new{
                        src=imageService.ResizeIfLargerThan( res.Logo,96,96),
                        sizes= "96x96",
                        type= "image/png",
                        purpose= "maskable any"
                    }, new{
                          src= res.Logo,
                          sizes= "144x144",
                          type= "image/png",
                          purpose= "maskable any"
                        }
                }
            };
            return new JsonResult(manifest);
        }
    }
}