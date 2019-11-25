using Evo.WebApi.Models.Enums;
using Evo.WebApi.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoDB.WebApi.Validators
{
    public class PersonValidator : AbstractValidator<StarRequest>
    {
        public PersonValidator()
        {
            RuleFor(r => r.FirstName)
                .NotEmpty()
                .Length(1, 64);

            RuleFor(r => r.MiddleName).Length(0, 64);
            RuleFor(r => r.LastName).Length(0, 64);
            RuleFor(r => r.Suffix).Length(0, 64);
            RuleFor(r => r.Role).NotEqual(PersonType.None);
        }
    }
}
