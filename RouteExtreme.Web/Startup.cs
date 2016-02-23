using RouteExtreme.Web.App_Start;
using Microsoft.Owin;
using Owin;
using System.Reflection;

[assembly: OwinStartupAttribute(typeof(RouteExtreme.Web.Startup))]
namespace RouteExtreme.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DatabaseConfig.Initialize();
            ConfigureAuth(app);
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(Assembly.GetExecutingAssembly());
            app.MapSignalR();
        }
    }
}
