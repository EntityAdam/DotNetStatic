using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetStaticReference
{
#pragma warning disable CA1052 // Static holder types should be Static or NotInheritable

    public class Startup
#pragma warning restore CA1052 // Static holder types should be Static or NotInheritable
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles(new StaticFileOptions()
            {
                ServeUnknownFileTypes = true
            });

            app.UseFileServer(new FileServerOptions()
            {
                EnableDirectoryBrowsing = true,
            });
        }
    }
}