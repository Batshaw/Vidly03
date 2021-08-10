using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly03.Startup))]
namespace Vidly03
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
