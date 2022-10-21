using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CartMidTask2.Startup))]
namespace CartMidTask2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
