using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tieto.TSU.Performance.DataService.Model;

namespace Tieto.TSU.Performance.DataService.Validators
{
    public class ContactValidator: AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(a => a.Mobile).NotEmpty()
                .Must(b => b.Length == 10)
                .WithMessage("Mobile Number must be 10 digits")
                .Matches("^[0-9]+$");
            RuleFor(a => a.Address)
                .Matches("^[-_, @.A-Za-z0-9]*$").MaximumLength(50);
        }
    }
}