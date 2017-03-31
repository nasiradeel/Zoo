using Autofac;
using Autofac.Integration.WebApi;
using MFEX.Zoo.BusinessLogic;
using MFEX.Zoo.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace MFEX.Zoo.WebClient
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var builder = new ContainerBuilder();


            builder.RegisterAssemblyModules(Assembly.Load("MFEX.Zoo.BusinessLogic"));
            builder.RegisterAssemblyModules(Assembly.Load("MFEX.Zoo.BusinessLogic.Interface"));
            
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;
            //AutofacHostFactory.Container = container;

            // In order to avoid recursive json serialization:
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
