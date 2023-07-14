using Core.Models;

namespace PanelIdentity.Extensions
{
    public static class SettingExtensions
    { 
        public static void AddSettingServices(this IServiceCollection services, IConfiguration Configuration)
        {
            #region ApiServerSettings
            services.Configure<ApiServerSettings>(Configuration.GetSection("ApiServerSettings"));
            #endregion
 
        }

    }
}
