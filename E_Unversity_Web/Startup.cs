using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_Unversity_Web.Startup))]
namespace E_Unversity_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
