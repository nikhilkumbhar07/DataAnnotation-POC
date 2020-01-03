using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tieto.TSU.Performance.DataService.Validators;

namespace Tieto.TSU.Performance.DataService.Model
{
    public class User
    {
        public int Id { get; set; }
        public int? NotNullable { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public DateTime DateOfJoining { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RangeProp { get; set; }
        public Contact Contact { get; set; }
    }
}