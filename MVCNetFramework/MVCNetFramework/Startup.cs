using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCNetFramework.Startup))]
namespace MVCNetFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
