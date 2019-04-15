using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rezervasyon.Web.Startup))]
namespace Rezervasyon.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
