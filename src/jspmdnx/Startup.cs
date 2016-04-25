namespace jspmdnx
{
    using System;
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Hosting;
    using Microsoft.AspNet.Routing;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.PlatformAbstractions;

    public partial class Startup
    {
        private readonly IApplicationEnvironment applicationEnvironment;
        private readonly IConfiguration configuration;
        private readonly IHostingEnvironment hostingEnvironment;

        public Startup(IApplicationEnvironment applicationEnvironment, IHostingEnvironment hostingEnvironment)
        {
            this.applicationEnvironment = applicationEnvironment;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = ConfigureConfiguration(hostingEnvironment);
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureCachingServices(services);
            
            RouteOptions routeOptions = null;
            services.ConfigureRouting(
                x =>
                {
                    routeOptions = x;
                    ConfigureRouting(x);
                });

            IMvcBuilder mvcBuilder = services.AddMvc(
                mvcOptions =>
                {
                    ConfigureSecurityFilters(this.hostingEnvironment, mvcOptions.Filters);
                });

            ConfigureAntiforgeryServices(services, this.hostingEnvironment);
        }

        public void Configure(IApplicationBuilder application, ILoggerFactory loggerfactory)
        {
            application.UseIISPlatformHandler();
            application.UseStaticFiles();
            
            ConfigureDebugging(application, this.hostingEnvironment);
            ConfigureLogging(this.hostingEnvironment, loggerfactory, this.configuration);
            ConfigureErrorPages(application, this.hostingEnvironment);

            application.UseMvc();
        }
    }
}