using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Perpustakaan.Startup))]
namespace Perpustakaan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
