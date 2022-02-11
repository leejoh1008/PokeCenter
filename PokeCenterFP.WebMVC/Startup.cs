using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PokeCenterFP.WebMVC.Startup))]
namespace PokeCenterFP.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
