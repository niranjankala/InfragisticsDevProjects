using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InfragistcsDev.ASPNET.MVC.Startup))]
namespace InfragistcsDev.ASPNET.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
