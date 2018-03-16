namespace jspmdnx
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;

    public partial class Startup
    {
        private static void ConfigureErrorPages(IApplicationBuilder application)
        {
            application.UseDeveloperExceptionPage();
        }
    }
}
