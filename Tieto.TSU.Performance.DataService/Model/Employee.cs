using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tieto.TSU.Framework.Client.Core;
using Tieto.TSU.Performance.DataService.Filters;

namespace Tieto.TSU.Performance.DataService.Model
{
    public class Employee: IValidatableObject
    {
        [Required]
        [CustomRange(typeof(int), "IntMinRange", "IntMaxRange")]
        public int Id { get; set; }

        [MaxLength(10, ErrorMessage = "Please enter valid Mobile Number")]
        public string MobileNumber { get; set; }

        [MaxLength(10, ErrorMessage = "{0} Input exceeds max length")]
        [RegularExpression("^[-_, @.A-Za-z0-9]*$", ErrorMessage = "Please enter valid string for {0} ")]
        public string NonSpecialCharaters { get; set; }

        [RegularExpression(@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$",
            ErrorMessage = "Bad email id")]
        public string EmailId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }   

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResultList = new List<ValidationResult>();
            if (DateTime.Compare(StartDate, EndDate) > 0)
            {
                var validationResult = new ValidationResult("End date must be greater than start date");
                validationResultList.Add(validationResult);
            } 
            return validationResultList;
        }
    }
}