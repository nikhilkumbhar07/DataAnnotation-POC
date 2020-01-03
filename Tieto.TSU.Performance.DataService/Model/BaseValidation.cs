using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tieto.TSU.Framework.Client.Core;

namespace Tieto.TSU.Performance.DataService.Model
{
    public class BaseValidation
    {
        private IConfigurationClient configurationClient;
        public IConfigurationClient Configuration
        { 
            set 
            {
                configurationClient = value;
            }
        }

    }
}