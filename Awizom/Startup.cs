using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Awizom.Startup))]
namespace Awizom
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
