using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PRDGSTTest_Client.Startup))]
namespace PRDGSTTest_Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
