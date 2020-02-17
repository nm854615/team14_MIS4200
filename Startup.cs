using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(team14_MIS4200.Startup))]
namespace team14_MIS4200
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
