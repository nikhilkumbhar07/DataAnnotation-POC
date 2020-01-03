using Autofac;
using FluentValidation.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.OData;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Tieto.TSU.Framework.Client.Core;
using Tieto.TSU.Performance.DataService.Filters;
using Tieto.TSU.Performance.DataService.Model;
using DomainModels = Tieto.TSU.Performance.Domain;

namespace Tieto.TSU.Performance.DataService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //IConfigurationClient configurationClient;
            //var containerBuilder = new ContainerBuilder();
            //containerBuilder.Register(a => new ConfigurationClient()).As<IConfigurationClient>();
            //containerBuilder.RegisterType<ConfigurationClient>().As<IConfigurationClient>();
            //var container = containerBuilder.Build();
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    configurationClient = scope.Resolve<IConfigurationClient>();
            //}
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new ValidateModelAttribute());
            config.Filters.Add(new SecondActionFilter());
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<DomainModels.Language>("Languages");

            //config.MapODataServiceRoute(
            //    routeName: "ODataRoute",
            //    routePrefix: "DaaS/Localization",
            //    model: builder.GetEdmModel()
            //    , defaultHandler: new ODataNullValueMessageHandler() { InnerHandler = new HttpControllerDispatcher(config) }
            //    );
            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );

            FluentValidationModelValidatorProvider.Configure(config);
            // Enable web api tracing.
            //config.EnableSystemDiagnosticsTracing();
        }
    }
}
