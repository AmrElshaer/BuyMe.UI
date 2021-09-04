using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(BuyMe.UI.Areas.Identity.IdentityHostingStartup))]

namespace BuyMe.UI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}