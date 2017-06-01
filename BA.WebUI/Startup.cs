using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BA.WebUI.Startup))]
namespace BA.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
