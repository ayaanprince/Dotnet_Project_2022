using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EF.Startup))]
namespace EF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
