using BuyMe.Application.Common.Interfaces;
using BuyMe.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.UI.Controllers.api
{
    
    public class ManifestController:BaseController
    {
        private readonly MarketingSettings _options;
        public ManifestController(IOptions<MarketingSettings> options)
        {
            _options = options.Value;
        }
        [HttpGet]
        public IActionResult GetManifest(string company)
        {
            var manifest =new
            {
                name= company,
                short_name= company,
                theme_color= "#1976d2",
                background_color= "#fafafa",
                display= "standalone",
                scope=$"{_options.Domain}/",
                start_url = $"{_options.Domain}/{company}",
                icons=new List<object>() {
                    new{
                        src= $"{_options.Domain}/assets/icons/icon-72x72.png",
                        sizes= "72x72",
                        type= "image/png",
                        purpose= "maskable any"
                    },
                    new{
                        src= $"{_options.Domain}/assets/icons/icon-96x96.png",
                        sizes= "96x96",
                        type= "image/png",
                        purpose= "maskable any"
                    }, new{
                          src= $"{_options.Domain}/assets/icons/icon-144x144.png",
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
