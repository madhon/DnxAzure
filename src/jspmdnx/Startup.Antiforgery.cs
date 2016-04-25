namespace jspmdnx
{
    using Microsoft.AspNet.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public partial class Startup
    {
        private static void ConfigureAntiforgeryServices(IServiceCollection services, IHostingEnvironment environment)
        {
            services.ConfigureAntiforgery(
                antiforgeryOptions =>
                {
                    antiforgeryOptions.CookieName = "f";
                    antiforgeryOptions.FormFieldName = "f";
                });
        }
    }
}
