using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Localization;
using PanelIdentity.Security;
using System.Globalization;
using PanelIdentity.Extensions;
using Identity.Business.DependencyResolvers.Autofac;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager Configuration = builder.Configuration;
IWebHostEnvironment Environment = builder.Environment;


// Add services to the container.
#region ConfigureServices
#region Authorize Jwt Token Ayarlarý
var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();


builder.Services.AddAuthentication("Bearer")
.AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("Bearer", null);

builder.Services.AddAuth(tokenOptions, Configuration);
#endregion


//#region AUTO MAPPER
//builder.Services.AddAutoMapper(typeof(MapProfile).Assembly);
//#endregion
//#region Autofac
//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
//                .ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));
//#endregion

#region Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));
#endregion

#region SETTINGS
builder.Services.AddSettingServices(Configuration);
#endregion
#region HttpClients
builder.Services.AddHttpClientServices(Configuration);
#endregion
#region CoreModule
builder.Services.AddDependencyResolvers(new ICoreModule[] { new CoreModule() });
#endregion
#region Mem-Cache / Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
#endregion
builder.Services.AddSwaggerExt();

builder.Services.AddMvc();
builder.Services.AddCors();
#endregion
// -------------------------------------------------------------------------------------------------------------//
#region Configure

var app = builder.Build();

// Configure the HTTP request pipeline.
app.Environment.EnvironmentName = Environments.Development;//Yayýnlama ortamýnda buranýn "Production" olmasý gerekiyor.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();

}
app.UseSwagger(c => c.RouteTemplate = "swagger/{documentName}/swagger.json");
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PanelIdentity Api v1.1.80");
    c.RoutePrefix = "swagger";
}
);
#region Default Culture
var defaultCulture = Configuration["SiteLocale"] ?? "tr-TR";
RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions
{
    SupportedCultures = new List<CultureInfo> { new CultureInfo(defaultCulture) },
    SupportedUICultures = new List<CultureInfo> { new CultureInfo(defaultCulture) },
    DefaultRequestCulture = new RequestCulture(defaultCulture),
};
app.UseRequestLocalization(localizationOptions);
#endregion
app.ConfigureCustomExceptionMiddleware();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuth();
app.UseSession();
app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

#region SeedData
#endregion
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
#endregion