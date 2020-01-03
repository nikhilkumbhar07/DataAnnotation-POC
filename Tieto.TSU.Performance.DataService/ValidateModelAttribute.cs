using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;
using Tieto.TSU.Framework.Client.Core;
using Tieto.TSU.Performance.DataService.CustomAttributes;

namespace Tieto.TSU.Performance.DataService
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            #region commented 
            //// Validate Data annotations
            //List<ValidationResult> validationResults = new List<ValidationResult>();
            //var values = actionContext.ActionArguments.Values;
            //foreach (var item in values)
            //{
            //    var validationContext = new ValidationContext(item, null, null);
            //    var isValid = Validator.TryValidateObject(item, validationContext, validationResults, true);
            //}
            //var errors = validationResults.Select(a => a.ErrorMessage);
            //if (errors != null && errors.Any())
            //    actionContext.Response = new HttpResponseMessage(statusCode: System.Net.HttpStatusCode.BadRequest) { Content = new StringContent(JsonConvert.SerializeObject(errors)) };
            ////
            #endregion

            if (actionContext.ActionDescriptor.GetCustomAttributes<SkipActionFilterAttribute>().Any()) return;
            else if (!actionContext.ModelState.IsValid)
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    actionContext.ModelState);
        }
    }
}