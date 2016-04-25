namespace jspmdnx
{
    using Microsoft.AspNet.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    public partial class Startup
    {
        private static void ConfigureLogging(
            IHostingEnvironment environment,
            ILoggerFactory loggerFactory,
            IConfiguration configuration)
        {
            if (environment.IsDevelopment())
            {

                loggerFactory.MinimumLevel = LogLevel.Debug;
                loggerFactory.AddConsole();
                loggerFactory.AddDebug();
            }
        }
    }
}
