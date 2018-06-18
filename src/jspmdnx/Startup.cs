namespace jspmdnx
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public partial class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IHostingEnvironment hostingEnvironment;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = ConfigureConfiguration(hostingEnvironment);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureCachingServices(services);

            RouteOptions routeOptions = null;

            services.AddRouting(
                x =>
                {
                    routeOptions = x;
                    ConfigureRouting(x);
                });

            var mvcBuilder = services.AddMvc(
                mvcOptions =>
                {
                    ConfigureSecurityFilters(this.hostingEnvironment, mvcOptions.Filters);
                }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);;

            ConfigureAntiforgeryServices(services, this.hostingEnvironment);
        }


        public void Configure(IApplicationBuilder application, ILoggerFactory loggerfactory)
        {
            application.UseStaticFiles();
            ConfigureDebugging(application, this.hostingEnvironment);
            ConfigureErrorPages(application);
            application.UseMvc();
        }
    }
}
