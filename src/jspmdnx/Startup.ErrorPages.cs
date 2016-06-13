namespace jspmdnx
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;

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
