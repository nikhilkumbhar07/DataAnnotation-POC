using FluentValidation.WebApi;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tieto.TSU.Framework.Client.Core;
using Tieto.TSU.Performance.DataService.CustomAttributes;
using Tieto.TSU.Performance.DataService.Model;
using Tieto.TSU.Performance.DataService.Validators;

namespace Tieto.TSU.Performance.DataService.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IConfigurationClient configurationClient;
        public UserController(IConfigurationClient configurationClient)
        {
            this.configurationClient = configurationClient;
        }

        [HttpPost]
        [Route("save")]
        [SkipActionFilter]
        public HttpResponseMessage Save(User user)
        {
            var validator = new UserValidator(configurationClient);
            var validationResult = validator.Validate(user);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState, null);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("savelist")]
        [SkipActionFilter]
        public HttpResponseMessage SaveList(List<User> users)
        {
            var validator = new UserListValidator(configurationClient);
            var validationResult = validator.Validate(users);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState, null);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
