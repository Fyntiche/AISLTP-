using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AISLTP.Startup))]
namespace AISLTP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
