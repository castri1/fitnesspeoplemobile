using Core.Data;
using Data;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;
using Services;
using System.Web.Http;
using Unity.WebApi;

namespace FitnessPeopleMobile
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var container = new UnityContainer();
            container.RegisterType(typeof(IRepository<>), typeof(EfRepository<>), new HierarchicalLifetimeManager(), new InjectionConstructor("FitnessPeople"));
            container.RegisterType<IProductService, ProductService>(new TransientLifetimeManager());
            config.DependencyResolver = new UnityDependencyResolver(container);

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}