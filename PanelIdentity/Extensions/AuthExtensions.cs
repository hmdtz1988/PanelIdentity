using Core.Utilities.Security.Jwt;

namespace PanelIdentity.Extensions
{
    public static class AuthExtensions
    {
        private static TokenOptions _tokenOptions;
        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            TokenOptions tokenOptions, ConfigurationManager Configuration)
        {
            _tokenOptions = tokenOptions;
            return services;
        }

        public static IApplicationBuilder UseAuth(this IApplicationBuilder app)
        {
            //AllowAnyHeader: Belirlenen domainlerden gelen her türlü isteğe izin ver.
            //app.UseCors(builders => builders.WithOrigins(_tokenOptions.Origins).AllowAnyHeader());

            app.UseAuthentication();//Giriş anahtarları.Giriş güvenliği.
            app.UseAuthorization();//Bir yere girildiğinde neler yapılacağı ile ilgili kontroller. Yetkilendirmeler.

            return app;
        }
    }
}