using IE_Clinics.Models.Access_Layer;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using System.Globalization;

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
