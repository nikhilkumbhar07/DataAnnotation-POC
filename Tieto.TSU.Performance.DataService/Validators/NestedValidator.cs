using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tieto.TSU.Performance.DataService.Model;

namespace Tieto.TSU.Performance.DataService.Validators
{
    public class NestedValidator:AbstractValidator<Nested>
    {
        public NestedValidator()
        {
            RuleFor(a => a.Id)
                .InclusiveBetween(3, 10);
        }
    }
}