using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tieto.TSU.Performance.DataService.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method)] 
    public class SkipActionFilterAttribute : Attribute
    {

    }
}