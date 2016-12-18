using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(web.BloodDonerManagement.Startup))]
namespace web.BloodDonerManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
