using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MyWebSite.Areas.Identity.IdentityHostingStartup))]
namespace MyWebSite.Areas.Identity
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