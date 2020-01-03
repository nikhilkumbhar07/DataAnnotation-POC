using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tieto.TSU.Framework.Client.Core;
using Tieto.TSU.Performance.DataService.Filters;
using Tieto.TSU.Performance.DataService.Model;

namespace Tieto.TSU.Performance.DataService.AutofacModule
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<ConfigurationClient>().As<IConfigurationClient>();
            builder.RegisterType<CustomRangeAttribute>().PropertiesAutowired();
            builder.RegisterType<Employee>().PropertiesAutowired();
            //builder.RegisterType<CustomRangeAttribute>().OnActivating(x => x.Instance.ConfigurationClient = x.Context.Resolve<IConfigurationClient>());
        }
    }
}