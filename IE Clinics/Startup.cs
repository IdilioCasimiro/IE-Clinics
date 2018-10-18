using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IE_Clinics.Startup))]
namespace IE_Clinics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
