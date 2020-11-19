namespace jspmdnx
{
    using Microsoft.Extensions.DependencyInjection;

    public partial class Startup
    {
        private static void ConfigureAntiForgeryServices(IServiceCollection services)
        {
            services.AddAntiforgery(
                antiForgeryOptions =>
                {
                    antiForgeryOptions.Cookie.Name = "f";
                    antiForgeryOptions.FormFieldName = "f";
                });
        }
    }
}
