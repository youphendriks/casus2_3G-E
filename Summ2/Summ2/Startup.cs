using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Summ2.Startup))]
namespace Summ2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
