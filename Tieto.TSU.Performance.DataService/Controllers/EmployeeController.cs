using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tieto.TSU.Performance.DataService.Filters;
using Tieto.TSU.Performance.DataService.Model;

namespace Tieto.TSU.Performance.DataService.Controllers
{
    [RoutePrefix("api/employee")]
    //[CustomRange]
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var modelData = GetData(id);
            var validationResults = new List<ValidationResult>();

            return ValidateObject(modelData, validationResults) ?
               Ok(JsonConvert.SerializeObject(modelData)) :
               Ok(JsonConvert.SerializeObject(validationResults.Select(a => a.ErrorMessage)));
        }

        [HttpPost]
        public IHttpActionResult AddEmployee(Employee employee)
        {
            //var validationResults = new List<ValidationResult>();
            //try
            //{
            //    return ValidateObject(employee, validationResults) ?
            //    Ok("true") :
            //    Ok(JsonConvert.SerializeObject(validationResults.Select(a => a.ErrorMessage)));
            //}
            //catch (Exception e)
            //{

            //    throw e;
            //}
            return Ok();
        }
        private Employee GetData(int id) => new Employee { Id = id, EmailId = "n.k@tieto.com", MobileNumber = "8597454556", NonSpecialCharaters = "FR@F$", StartDate = DateTime.Now, EndDate = new DateTime(2020, 02, 16) };

        private bool ValidateObject(object modelData, List<ValidationResult> validationResults)
        {
            var validationContext = new ValidationContext(modelData, null, null);
            var isValid = Validator.TryValidateObject(modelData, validationContext, validationResults, true);
            return isValid;
        }
    }
}
