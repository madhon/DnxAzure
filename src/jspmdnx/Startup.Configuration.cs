namespace jspmdnx
{
    using Microsoft.AspNet.Hosting;
    using Microsoft.Extensions.Configuration;

    public partial class Startup
    {
        private static IConfiguration ConfigureConfiguration(IHostingEnvironment hostingEnvironment)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("config.json");
            configurationBuilder.AddEnvironmentVariables();
            return configurationBuilder.Build();
        }
    }
}
