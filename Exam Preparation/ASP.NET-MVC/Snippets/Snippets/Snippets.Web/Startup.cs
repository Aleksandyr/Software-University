using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Snippets.Web.Startup))]
namespace Snippets.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
