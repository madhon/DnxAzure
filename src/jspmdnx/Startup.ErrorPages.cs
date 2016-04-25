namespace jspmdnx
{
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Hosting;

    public partial class Startup
    {
        private static void ConfigureErrorPages(
            IApplicationBuilder application,
            IHostingEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
            }
            else
            {
                application.UseExceptionHandler("/Home/Error");

            }
        }
    }
}
