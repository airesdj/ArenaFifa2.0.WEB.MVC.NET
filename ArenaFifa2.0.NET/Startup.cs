using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArenaFifa2._0.NET.Startup))]
namespace ArenaFifa2._0.NET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
