using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cook.Startup))]
namespace Cook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
