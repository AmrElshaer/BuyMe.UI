using BuyMe.Application.Common.Behaviour;
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
            Guard.Against.Null(res,"Company");
            var logo = imageService.ResizeIfLargerThan(res.Logo, 144, 144);
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
                        src=imageService.ResizeIfLargerThan(logo,72,72),
                        sizes= "72x72",
                        type= "image/png",
                        purpose= "maskable any"
                    },
                    new{
                        src=imageService.ResizeIfLargerThan(logo,96,96),
                        sizes= "96x96",
                        type= "image/png",
                        purpose= "maskable any"
                    }
                    , new{
                          src=imageService.ResizeIfLargerThan(res.Logo, 128, 128),
                          sizes= "128x128",
                          type= "image/png",
                          purpose= "maskable any"
                        }, new{
                          src=imageService.ResizeIfLargerThan(res.Logo, 144, 144),
                          sizes= "144x144",
                          type= "image/png",
                          purpose= "maskable any"
                        } ,
                    new
                    {
                        src = imageService.ResizeIfLargerThan(res.Logo, 152, 152),
                        sizes = "152x152",
                        type = "image/png",
                        purpose = "maskable any"
                    },
                    new
                    {
                        src = imageService.ResizeIfLargerThan(res.Logo, 192, 192),
                        sizes = "192x192",
                        type = "image/png",
                        purpose = "maskable any"
                    }
                            ,
                    new
                    {
                        src = imageService.ResizeIfLargerThan(res.Logo, 384, 384),
                        sizes = "384x384",
                        type = "image/png",
                        purpose = "maskable any"
                    },
                    new
                    {
                        src = imageService.ResizeIfLargerThan(res.Logo, 512, 512),
                        sizes = "512x512",
                        type = "image/png",
                        purpose = "maskable any"
                    }
            }
            };
            return new JsonResult(manifest);
        }
    }
}