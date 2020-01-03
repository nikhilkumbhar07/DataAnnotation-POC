using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tieto.TSU.Framework.Client.Core;
using Tieto.TSU.Performance.DataService.Model;

namespace Tieto.TSU.Performance.DataService.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        private const string OnPremise = "OnPremise";
        private const string Cloud = "Cloud";
        private readonly IConfigurationClient configurationClient;
        public UserValidator(IConfigurationClient configurationClient)
        {
            this.configurationClient = configurationClient;
            RuleFor(a => a.Id)
                .NotNull()
                .InclusiveBetween(1, 5);
            RuleFor(a => a.FirstName)
                .NotEmpty();
            RuleFor(a => a.LastName)
                .NotEmpty()
                .Must((a, b) => string.Compare(a.FirstName, b) != 0)
                .WithMessage("FirstName and LastName must not be same");
            RuleFor(a => a.Email)
                .EmailAddress();
            RuleFor(a => a.EndDate)
                .GreaterThanOrEqualTo(b => b.StartDate);
            RuleFor(a => a.RangeProp)
                .InclusiveBetween(1, Convert.ToInt32(configurationClient.GetConfiguration("UserNameLengthValidation")));
            RuleFor(a => a.Age)
                .InclusiveBetween(18, 65);
            RuleFor(a => a.NotNullable)
                .NotNull();
            RuleFor(a => a.UserName)
                .Must(b => ValidateUserName(configurationClient.GetConfiguration("InstallationType"), b))
                .WithMessage("User name is not valid");
        }

        private bool ValidateUserName(string installationType, string content)
        {
            if (installationType == OnPremise)
                return content.Contains("/");
            else if (installationType == Cloud)
                return content.Contains("@");
            return false;
        }
    }
}