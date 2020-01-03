using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tieto.TSU.Performance.DataService.Validators;

namespace Tieto.TSU.Performance.DataService.Model
{
    [Validator(typeof(NestedValidator))]
    public class Nested
    {
        public int Id { get; set; }

    }
}