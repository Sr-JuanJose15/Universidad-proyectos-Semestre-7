using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Colegio_v3.Startup))]
namespace Colegio_v3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
