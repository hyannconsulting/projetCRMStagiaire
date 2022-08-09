using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetStagiaireCRM.Startup))]
namespace ProjetStagiaireCRM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
