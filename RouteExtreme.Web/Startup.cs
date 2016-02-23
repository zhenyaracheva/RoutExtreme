using RouteExtreme.Web.App_Start;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RouteExtreme.Web.Startup))]
namespace RouteExtreme.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DatabaseConfig.Initialize();
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
