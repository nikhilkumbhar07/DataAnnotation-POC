using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tieto.TSU.Framework.Client.Core;
using Tieto.TSU.Performance.DataService.Model;

namespace Tieto.TSU.Performance.DataService.Validators
{
    public class UserListValidator:AbstractValidator<List<User>>
    {
        private readonly IConfigurationClient configurationClient;
        public UserListValidator(IConfigurationClient configurationClient)
        {
            this.configurationClient = configurationClient;
            RuleForEach(user => user).SetValidator(new UserValidator(configurationClient));
        }
    }
}