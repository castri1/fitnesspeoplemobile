using FitnessPeopleMobile;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Startup))]
namespace FitnessPeopleMobile
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            //UnityConfig.RegisterComponents();
            WebApiConfig.Register(config);
            ConfigureAuthZero(app);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }
}