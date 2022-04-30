using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ByMe.Presentation.Areas.Identity.IdentityHostingStartup))]

namespace ByMe.Presentation.Areas.Identity
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