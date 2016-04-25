namespace jspmdnx
{
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public partial class Startup
    {
        private static void ConfigureDebuggingServices(
            IServiceCollection services,
            IHostingEnvironment environment)
        {
            
        }

        private static void ConfigureDebugging(
            IApplicationBuilder application,
            IHostingEnvironment environment)
        {

            if (environment.IsDevelopment())
            {
                application.UseRuntimeInfoPage();
                application.UseBrowserLink();
            }
        }
    }
}
