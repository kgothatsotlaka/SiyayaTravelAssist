using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SiyayaTravelAssist.Startup))]
namespace SiyayaTravelAssist
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
