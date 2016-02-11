using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(graph.Startup))]
namespace graph
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
