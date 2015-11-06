using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HyperSlackers.DbContext.Demo.Startup))]
namespace HyperSlackers.DbContext.Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
