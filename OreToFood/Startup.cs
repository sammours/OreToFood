using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OreToFood.Startup))]
namespace OreToFood
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
