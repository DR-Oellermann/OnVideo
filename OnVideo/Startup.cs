using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnVideo.Startup))]
namespace OnVideo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
