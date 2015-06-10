using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cambealo.Startup))]
namespace Cambealo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
