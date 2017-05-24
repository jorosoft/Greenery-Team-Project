using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirportSystem.WebClient.Startup))]
namespace AirportSystem.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
