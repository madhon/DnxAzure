namespace jspmdnx
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public partial class Startup
    {
        private static void ConfigureDebuggingServices(
            IServiceCollection services,
            IWebHostEnvironment environment)
        {
            
        }

        private static void ConfigureDebugging(
            IApplicationBuilder application,
            IWebHostEnvironment environment)
        {

            if (environment.IsDevelopment())
            {
                //application.UseRuntimeInfoPage();
            }
        }
    }
}
