using jspmdnx;
using jspmdnx.LocalizationResources;
using XLocalizer;
using XLocalizer.Routing;
using XLocalizer.Translate.MyMemoryTranslate;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(o => o.AddServerHeader = false);

builder.Services.AddMemoryCache();

builder.Services.AddRouting(
    x =>
    {
        x.AppendTrailingSlash = true;
        x.LowercaseUrls = true;
    });

builder.Services.ConfigureLocalization();

builder.Services.AddRazorPages().AddRazorPagesOptions(ops =>
{
    ops.Conventions.Insert(0, new RouteTemplateModelConventionRazorPages());
});


builder.Services.AddControllersWithViews()
    .AddMvcOptions(ops => { ops.Conventions.Insert(0, new RouteTemplateModelConventionMvc()); })
    .AddXLocalizer<LocSource, MyMemoryTranslateService>(ops =>
    {
        ops.ResourcesPath = "LocalizationResources";
        ops.AutoAddKeys = true;
        ops.AutoTranslate = true;
        ops.TranslateFromCulture = "en";
    });

builder.Services.AddAntiforgery(
    antiForgeryOptions =>
    {
        antiForgeryOptions.SuppressXFrameOptionsHeader = true;
        antiForgeryOptions.Cookie.Name = "f";
        antiForgeryOptions.FormFieldName = "f";
        antiForgeryOptions.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        antiForgeryOptions.Cookie.HttpOnly = true;
        antiForgeryOptions.HeaderName = "X-XSRF-TOKEN";
    });

var app = builder.Build();

app.AddCustomSecurityHeaders();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.UseStaticFiles();
app.UseRequestLocalization();
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();