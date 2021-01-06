using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectFiveP.Startup))]
namespace ProjectFiveP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
