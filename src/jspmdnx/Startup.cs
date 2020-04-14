namespace jspmdnx
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public partial class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment hostingEnvironment;

        public Startup(IWebHostEnvironment hostingEnvironment)
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

            services.AddMvc(
                mvcOptions =>
                {
                    ConfigureSecurityFilters(this.hostingEnvironment, mvcOptions.Filters);
                });

            ConfigureAntiForgeryServices(services);
        }


        public void Configure(IApplicationBuilder application)
        {
            application.UseStaticFiles();
            application.UseRouting();

            ConfigureErrorPages(application);

            application.UseEndpoints( endpoints => endpoints.MapDefaultControllerRoute());
        }
    }
}
