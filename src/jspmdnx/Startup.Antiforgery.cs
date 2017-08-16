namespace jspmdnx
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public partial class Startup
    {
        private static void ConfigureAntiforgeryServices(IServiceCollection services, IHostingEnvironment environment)
        {
            services.AddAntiforgery(
                antiforgeryOptions =>
                {
                    antiforgeryOptions.Cookie.Name = "f";
                    antiforgeryOptions.FormFieldName = "f";
                });
        }
    }
}
