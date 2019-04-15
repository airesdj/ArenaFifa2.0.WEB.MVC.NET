using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArenaFifa20.NET.Startup))]
namespace ArenaFifa20.NET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
