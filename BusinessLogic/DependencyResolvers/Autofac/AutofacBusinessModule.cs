using Autofac;
using Autofac.Extras.DynamicProxy;
using BusinessLogic.Action;
using BusinessLogic.Interface;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging.Log4Net.Service;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;

namespace Identity.Business.DependencyResolvers.Autofac
{
    //Bu modülü projelerde çağırmak için "Autofac.Extensions.DependencyInjection" eklentisini ilgili projeye nugetten eklenmesi gerekiyor.    
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region AddScoped/InstancePerLifetimeScope

            #region Setting
            builder.RegisterType<Core.DataAccess.Dapper.Dapper>().As<Core.DataAccess.Dapper.IDapper>();
            #endregion

            #endregion

            #region AddTransient/InstancePerDependency

            #region Others
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().InstancePerDependency();
            builder.RegisterType<TokenAction>().As<ITokenService>().InstancePerDependency();
            #endregion

            #endregion

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }
                ).SingleInstance();
        }
    }
}
