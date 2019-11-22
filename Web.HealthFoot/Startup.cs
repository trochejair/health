using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web.HealthFoot.Startup))]
namespace Web.HealthFoot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
