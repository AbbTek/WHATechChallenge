using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WHACodeChallenge.Startup))]
namespace WHACodeChallenge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
