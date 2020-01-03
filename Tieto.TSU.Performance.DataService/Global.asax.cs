using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using Common.Logging;
using Tieto.TSU.Framework.Bootstrap;
using Tieto.TSU.Framework.Bootstrap.Autofac.WebApi;
using Tieto.TSU.Framework.Client.Core;
using Tieto.TSU.Framework.Definitions;

namespace Tieto.TSU.Performance.DataService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public string Maxlimit { get; set; }
        protected void Application_Start()
        {
            Bootstrapper bootstrapper = new AutoFacWebApiBootstrapper()
            {
                ApplicationType = Framework.Definitions.ApplicationType.WebApi,
                EnableRegisterApplicaiton = false,
                EnableCaching = false,
                BuiltInCacheLoadTypesToInclude = null,
                EnableApiSecurity = true,
                EnableErrorHandling = false,
                ApplicationName = "Datatest",
                ModuleName = "Platform",
                EnableDynamicCaching = false
            };
            bootstrapper.Initialize();

            GlobalConfiguration.Configuration.DependencyResolver = (IDependencyResolver)bootstrapper.DependencyResolver;
            var builder = new ContainerBuilder();
            builder.Register(a => new ConfigurationClient()).As<IConfigurationClient>();
            builder.RegisterType<ConfigurationClient>().As<IConfigurationClient>();
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var reader = scope.Resolve<IConfigurationClient>();
                Maxlimit = reader.GetConfiguration("UserNameLengthValidation");
            }
            //ConfigurationManager.AppSettings.Add("MaxLimit", Maxlimit);
            var localConfig = WebConfigurationManager.OpenWebConfiguration("~");
            var appSettings = (AppSettingsSection)localConfig.GetSection("appSettings");
            if (appSettings != null)
            {
                if (string.Compare(Maxlimit, appSettings.Settings["MaxLimit"].Value) != 0)
                {
                    appSettings.Settings["MaxLimit"].Value = Maxlimit;
                    localConfig.Save();
                }
            }
                        
            ILog logger = LogManager.GetLogger(typeof(WebApiApplication));
            logger.Trace("Trace entry using Tieto.TSU.Performance.DataService -> Application_Start");

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
