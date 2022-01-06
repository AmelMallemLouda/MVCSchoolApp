using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoolApp.Startup))]
namespace ShoolApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
