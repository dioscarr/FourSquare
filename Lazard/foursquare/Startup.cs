using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(foursquare.Startup))]
namespace foursquare
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
