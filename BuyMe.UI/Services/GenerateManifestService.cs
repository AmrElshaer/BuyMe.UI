using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Company.Queries;
using BuyMe.UI.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Drawing.Imaging;

namespace BuyMe.UI.Services
{
    public class GenerateManifestService : IGenerateManifestService
    {
        private readonly MarketingSettings _options;
        private readonly IImageService imageService;

        public GenerateManifestService(IOptions<MarketingSettings> options, IImageService imageService)
        {
            _options = options.Value;
            this.imageService = imageService;
        }

        public object GenerateManifest(CompanyDto company)
        {
            Guard.Against.Null(company, "Company");
            var result = new
            {
                name = company.Name,
                short_name = company.Name,
                theme_color = "#1976d2",
                background_color = "#fafafa",
                display = "standalone",
                scope = $"{_options.Domain}/{company.Name}",
                start_url = $"{_options.Domain}/{company.Name}",
                icons = new List<object>() {
                new{
                    src=imageService.ResizeImage(company.Logo,72,72,ImageFormat.Png),
                    sizes= "72x72",
                    type= "image/png",
                    purpose= "maskable any"
                },
                new{
                    src=imageService.ResizeImage(company.Logo,96,96,ImageFormat.Png),
                    sizes= "96x96",
                    type= "image/png",
                    purpose= "maskable any"
                   },
                 new{
                     src=imageService.ResizeImage(company.Logo, 144, 144,ImageFormat.Png),
                     sizes= "144x144",
                     type= "image/png",
                     purpose= "maskable any"
                 }
                }
            };
            return result;
        }
    }
}