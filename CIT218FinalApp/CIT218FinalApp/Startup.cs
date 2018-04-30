using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CIT218FinalApp.Startup))]
namespace CIT218FinalApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
