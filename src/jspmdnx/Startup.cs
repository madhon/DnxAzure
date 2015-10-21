namespace jspmdnx
{
  using System;
  using Microsoft.AspNet.Builder;
  using Microsoft.AspNet.Hosting;
  using Microsoft.Dnx.Runtime;
  using Microsoft.Framework.Configuration;
  using Microsoft.Framework.DependencyInjection;
  using Microsoft.Framework.Logging;

  public class Startup
  {
    public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(appEnv.ApplicationBasePath)
        .AddJsonFile("config.json")
        .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfiguration Configuration { get; set; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      app.UseIISPlatformHandler();
      app.UseRuntimeInfoPage();
      loggerFactory.MinimumLevel = LogLevel.Information;

      if (env.IsDevelopment())
      {
        loggerFactory.AddConsole();
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseStaticFiles();

      app.UseMvc(routes =>
      {
        routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}