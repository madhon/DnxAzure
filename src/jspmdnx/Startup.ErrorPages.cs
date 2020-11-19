namespace jspmdnx
{
    using Microsoft.AspNetCore.Builder;

    public partial class Startup
    {
        private static void ConfigureErrorPages(IApplicationBuilder application)
        {
            application.UseDeveloperExceptionPage();
        }
    }
}
