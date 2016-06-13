namespace jspmdnx
{
    using Microsoft.AspNetCore.Routing;

    public partial class Startup
    {
        private static void ConfigureRouting(RouteOptions routeOptions)
        {
            routeOptions.AppendTrailingSlash = true;
            routeOptions.LowercaseUrls = true;
        }
    }
}
