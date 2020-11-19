namespace jspmdnx
{
    using System.Globalization;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.Extensions.DependencyInjection;
    using XLocalizer;
    using XLocalizer.Routing;
    using XLocalizer.Translate;
    using XLocalizer.Translate.MyMemoryTranslate;
    using XLocalizer.Xml;

    public static class ServiceCollectionExtensions
    {
        public static void ConfigureLocalization(this IServiceCollection services)
        {
            services.Configure<RequestLocalizationOptions>(ops =>
            {
                var cultures = new CultureInfo[]
                {
                    new CultureInfo("en"),
                    new CultureInfo("fr")
                };

                ops.SupportedCultures = cultures;
                ops.SupportedUICultures = cultures;
                ops.DefaultRequestCulture = new RequestCulture("en");
                ops.RequestCultureProviders.Insert(0, new RouteSegmentRequestCultureProvider(cultures));

                
            });

            services.AddSingleton<IXResourceProvider, XmlResourceProvider>();
            services.AddHttpClient<ITranslator, MyMemoryTranslateService>();
        }
    }
}
