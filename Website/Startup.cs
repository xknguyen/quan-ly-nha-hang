using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Website_Nhà_Hàng.Startup))]
namespace Website_Nhà_Hàng
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
