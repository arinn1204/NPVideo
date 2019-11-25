using Evo.WebApi.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoDB.WebApi.Validators
{

    public class RatingValidator : AbstractValidator<RatingRequest>
    {
        public RatingValidator()
        {
            RuleFor(r => r.Source).NotEmpty().Length(1, 32);
            RuleFor(r => r.RatingValue).LessThanOrEqualTo(100.00m).GreaterThan(0m);
        }
    }
}
