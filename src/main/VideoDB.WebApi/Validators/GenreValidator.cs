using Evo.WebApi.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoDB.WebApi.Validators
{
    public class GenreValidator : AbstractValidator<GenreRequest>
    {
        public GenreValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .Length(1, 32);
        }
    }
}
