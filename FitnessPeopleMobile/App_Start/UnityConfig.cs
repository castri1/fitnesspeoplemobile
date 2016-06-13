using Core.Data;
using Data;
using FitnessPeopleMobile.Controllers;
using Microsoft.Practices.Unity;
using Services;
using System.Web.Http;
using Unity.WebApi;

namespace FitnessPeopleMobile
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType(typeof(IRepository<>), typeof(EfRepository<>), new HierarchicalLifetimeManager(), new InjectionConstructor("FitnessPeople"));
            container.RegisterType<IProductService, ProductService>(new TransientLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}