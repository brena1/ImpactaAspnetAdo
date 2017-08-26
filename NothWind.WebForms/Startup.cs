using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NothWind.WebForms.Startup))]
namespace NothWind.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
