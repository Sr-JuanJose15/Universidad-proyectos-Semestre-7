using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eventos_2025_1.Startup))]
namespace eventos_2025_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
