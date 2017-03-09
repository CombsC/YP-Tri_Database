using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YPTriMembership.Startup))]
namespace YPTriMembership
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
