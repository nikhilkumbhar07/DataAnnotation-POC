using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tieto.TSU.Performance.DataService.Validators;

namespace Tieto.TSU.Performance.DataService.Model
{
    [Validator(typeof(ContactValidator))]
    public class Contact
    {
        public string Mobile { get; set; }
        public string Address { get; set; }

        public Nested Nested { get; set; }
    }
}