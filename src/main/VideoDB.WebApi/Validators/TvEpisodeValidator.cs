using Evo.WebApi.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoDB.WebApi.Validators
{
    public class TvEpisodeValidator : AbstractValidator<TvEpisodeRequest>
    {
        public TvEpisodeValidator()
        {
            RuleFor(r => r.VideoId)
                .NotEmpty()
                .Matches(@"^tt\d{7,9}$");

            RuleFor(r => r.TvEpisodeId)
                .NotEmpty()
                .Matches(@"^tt\d{7,9}$");

            RuleFor(r => r.Title).NotEmpty();
            RuleFor(r => r.MpaaRating).NotEmpty().Length(1, 8);
            RuleFor(r => r.Plot).NotEmpty();
            RuleFor(r => r.ReleaseDate).NotEqual(default(DateTime));
            RuleFor(r => r.EpisodeReleaseDate).NotEqual(default(DateTime));
            RuleFor(r => r.Runtime).LessThan(999.945m).GreaterThan(0m);
            RuleFor(r => r.SeasonNumber).GreaterThan(0);
            RuleFor(r => r.EpisodeNumber).GreaterThan(0);
            RuleFor(r => r.EpisodeName).NotEmpty();
            RuleFor(r => r.EpisodePlot).NotEmpty();
            RuleFor(r => r.Resolution).Length(0, 16);
            RuleFor(r => r.Codec).Length(0, 8);
            RuleFor(r => r.Extended).Length(0, 16);
        }
    }
}
