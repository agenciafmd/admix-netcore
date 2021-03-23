using Microsoft.AspNetCore.Hosting;
using WebAdmix.Areas.Identity;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]

namespace WebAdmix.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { });
        }
    }
}