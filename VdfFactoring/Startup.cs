using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VdfFactoring.Startup))]
namespace VdfFactoring
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
