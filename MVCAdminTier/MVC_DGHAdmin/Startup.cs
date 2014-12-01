using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_DGHAdmin.Startup))]
namespace MVC_DGHAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
