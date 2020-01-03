using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Tieto.TSU.Framework.Client.Core;

namespace Tieto.TSU.Performance.DataService.Filters
{
    public class CustomRangeAttribute : RangeAttribute
    {
        //private readonly static IConfigurationBuilder builder = new ConfigurationBuilder()
        //       .SetBasePath(Directory.GetCurrentDirectory())
        //       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //private readonly static IConfigurationRoot config = builder.Build();

        //private static IConfigurationClient configurationClient;
        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    configurationClient = (IConfigurationClient)validationContext.GetService(typeof(IConfigurationClient));
        //    return base.IsValid(value, validationContext);
        //}

        /// <summary>
        /// Validate field against range provided in config.
        /// </summary>
        /// <param name="type">Provide type of the field to be validate</param>
        /// <param name="minValueKey">Provide config key for min value limit</param>
        /// <param name="maxValueKey">Provide config key for max value limit</param>


        public CustomRangeAttribute(Type type, string minValueKey, string maxValueKey)
            : base(type, "1", ConfigurationManager.AppSettings["MaxLimit"])
        {

        }
    }
}