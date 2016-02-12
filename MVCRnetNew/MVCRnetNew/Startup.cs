using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCRnetNew.Startup))]
namespace MVCRnetNew
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
