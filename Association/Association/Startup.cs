using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Association.Startup))]
namespace Association
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
