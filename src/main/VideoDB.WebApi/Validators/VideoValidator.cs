using Evo.WebApi.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoDB.WebApi.Validators
{
    public class VideoValidator : AbstractValidator<MovieRequest>
    {
        public VideoValidator()
        {
            RuleFor(request => request.VideoId)
                .NotEmpty()
                .Length(1, 32);

            RuleFor(request => request.MpaaRating)
                .NotEmpty()
                .Length(1, 8);

            RuleFor(request => request.Runtime)
                .LessThan(999.995M);

            RuleFor(r => r.Resolution).Length(0, 16);
            RuleFor(r => r.Extended).Length(0, 16);
            RuleFor(r => r.Codec).Length(0, 8);


            RuleFor(request => request.ReleaseDate).NotEqual(default(DateTime));
            RuleFor(request => request.Title).NotEmpty();
            RuleFor(request => request.Plot).NotEmpty();
        }
    }
}
