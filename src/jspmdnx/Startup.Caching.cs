namespace jspmdnx
{
    using Microsoft.Extensions.DependencyInjection;

    public partial class Startup
    {
        private static void ConfigureCachingServices(IServiceCollection services)
        {
            services.AddMemoryCache();
        }
    }
}
