using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PjaxExample.Startup))]
namespace PjaxExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
