namespace jspmdnx
{
    using LocalizationResources;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using XLocalizer;
    using XLocalizer.Routing;
    using XLocalizer.Translate.MyMemoryTranslate;

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

            services.AddRouting(
                x =>
                {
                    x.AppendTrailingSlash = true;
                    x.LowercaseUrls = true;
                });

            services.ConfigureLocalization();

            services.AddRazorPages().AddRazorPagesOptions(ops =>
            {
                ops.Conventions.Insert(0, new RouteTemplateModelConventionRazorPages());
            });

            services.AddControllersWithViews(
                mvcOptions =>
                {
                    ConfigureSecurityFilters(this.hostingEnvironment, mvcOptions.Filters);
                })
                .AddMvcOptions(ops => { ops.Conventions.Insert(0, new RouteTemplateModelConventionMvc()); })
                .AddXLocalizer<LocSource, MyMemoryTranslateService>(ops =>
                {
                    ops.ResourcesPath = "LocalizationResources";
                    ops.AutoAddKeys = true;
                    ops.AutoTranslate = true;
                    ops.TranslateFromCulture = "en";
                });

            ConfigureAntiForgeryServices(services);
        }


        public void Configure(IApplicationBuilder application)
        {
            application.UseStaticFiles();
            application.UseRequestLocalization();
            application.UseRouting();
            
            ConfigureErrorPages(application);

            application.UseEndpoints( endpoints => endpoints.MapDefaultControllerRoute());
        }
    }
}
