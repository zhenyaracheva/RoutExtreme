using BulBike.Web.App_Start;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BulBike.Web.Startup))]
namespace BulBike.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DatabaseConfig.Initialize();
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
