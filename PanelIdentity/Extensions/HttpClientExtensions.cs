
using Core.Models;
using Core.Static;
//using CoreService_DataTransfer.ApiDto.VakifPaysApiDtos;
//using CoreService_DataTransfer.Setting;
//using Customer_Entities.Setting;
//using CustomerApi.Handlers;

namespace PanelIdentity.Extensions
{
    public static class HttpClientExtensions
    {
        public static void AddHttpClientServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            var apiServerSettings = Configuration.GetSection("ApiServerSettings").Get<ApiServerSettings>();
            //var smsSettings = Configuration.GetSection("SmsSettings").Get<SmsSettings>();
            //var vakifPaysApiSettings = Configuration.GetSection("VakifPaysApiSettings").Get<VakifPaysApiSettings>();
            //var vakifBankApiSettings = Configuration.GetSection("VakifBankApiSettings").Get<VakifBankApiSettings>();
            
            //services.AddScoped<TokenInterceptorHandler>();
            //services.AddScoped<TokenAcrossAccessInterceptorHandler>();
            //services.AddScoped<VakifPaysTokenInterceptorHandler>();
            //services.AddScoped<VakifBankTokenInterceptorHandler>();
            //StaticLoginInfo.Configuration = Configuration;
           
            //services.AddHttpClient("identity", httpClient =>
            //{
            //    httpClient.BaseAddress = new Uri($"{apiServerSettings.IdentityBaseUri}");
            //}).AddHttpMessageHandler<TokenInterceptorHandler>();

            //services.AddHttpClient("identity_with_AcrossAccess", httpClient =>
            //{
            //    httpClient.BaseAddress = new Uri($"{apiServerSettings.IdentityBaseUri}");
            //}).AddHttpMessageHandler<TokenAcrossAccessInterceptorHandler>();

            ////services.AddHttpClient("ewallet", httpClient =>
            ////{
            ////    httpClient.BaseAddress = new Uri($"{apiServerSettings.EWalletBaseUri}");
            ////}).AddHttpMessageHandler<TokenInterceptorHandler>();

            //services.AddHttpClient("vakifpays", httpClient =>
            //{
            //    httpClient.BaseAddress = new Uri($"{vakifPaysApiSettings.BaseUrl}");
            //}).AddHttpMessageHandler<VakifPaysTokenInterceptorHandler>();

            //services.AddHttpClient("vakifbank", httpClient =>
            //{
            //    httpClient.BaseAddress = new Uri($"{vakifBankApiSettings.BaseUrl}");
            //}).AddHttpMessageHandler<VakifBankTokenInterceptorHandler>();
        }

    }
}
