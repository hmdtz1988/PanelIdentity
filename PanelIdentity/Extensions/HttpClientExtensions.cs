
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
        }

    }
}
