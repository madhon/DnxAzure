namespace jspmdnx
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    public partial class Startup
    {
        private static IConfiguration ConfigureConfiguration(IHostingEnvironment hostingEnvironment)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(hostingEnvironment.ContentRootPath);
            configurationBuilder.AddJsonFile("appsettings.json", optional: true);
            configurationBuilder.AddEnvironmentVariables();

            return configurationBuilder.Build();
        }
    }
}
