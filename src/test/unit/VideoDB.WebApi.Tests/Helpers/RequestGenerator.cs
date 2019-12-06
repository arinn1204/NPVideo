using AutoBogus;
using Bogus;
using Evo.WebApi.Models.Enums;
using Evo.WebApi.Models.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace VideoDB.WebApi.Tests.Helpers
{
    public class RequestGenerator
    {
        public static MovieRequest GetMovieRequest(int id = 0)
        {
            return new AutoFaker<MovieRequest>()
                .RuleFor(r => r.Actors, r => GetStars(3, PersonType.Actor))
                .RuleFor(r => r.Directors, r => GetStars(1, PersonType.Director))
                .RuleFor(r => r.Writers, r => GetStars(3, PersonType.Writer))
                .RuleFor(r => r.Producers, r => GetStars(3, PersonType.Producer))
                .RuleFor(r => r.Genres, r => GetGenres(3))
                .RuleFor(r => r.Ratings, r => GetRatings(2))
                .RuleFor(r => r.Title, r => string.Join(" ", r.Lorem.Words(new Random().Next(1, 10000))))
                .RuleFor(r => r.MpaaRating, r => GenerateString(r, 7))
                .RuleFor(r => r.Plot, r => string.Join(" ", r.Lorem.Words(new Random().Next(1, 100))))
                .RuleFor(r => r.Runtime, r => r.Finance.Amount(.01m, 999, 2))
                .RuleFor(r => r.Type, r => VideoType.Movie)
                .RuleFor(r => r.VideoId, r => $"tt{(id == 0 ? r.Random.Number(1000000, 999999999) : id)}")
                .RuleFor(r => r.Codec, r => GenerateString(r, 8))
                .RuleFor(r => r.Resolution, r => GenerateString(r, 16))
                .RuleFor(r => r.Extended, r => GenerateString(r, 16))
                .Generate();
        }

        public static TvEpisodeRequest GetTvEpisodeRequest(int seriesId = 0, int tvEpisodeId = 0)
        {
            return new AutoFaker<TvEpisodeRequest>()
                .RuleFor(r => r.Actors, r => GetStars(3, PersonType.Actor))
                .RuleFor(r => r.Directors, r => GetStars(1, PersonType.Director))
                .RuleFor(r => r.Writers, r => GetStars(3, PersonType.Writer))
                .RuleFor(r => r.Producers, r => GetStars(3, PersonType.Producer))
                .RuleFor(r => r.Genres, r => GetGenres(3))
                .RuleFor(r => r.Ratings, r => GetRatings(2))
                .RuleFor(r => r.VideoId, r => $"tt{(seriesId == 0 ? r.Random.Number(1000000,999999999) : seriesId)}")
                .RuleFor(r => r.TvEpisodeId, r => $"tt{(tvEpisodeId == 0 ? r.Random.Number(1000000, 999999999) : tvEpisodeId)}")
                .RuleFor(r => r.Title, r => "Series Title")
                .RuleFor(r => r.EpisodeName, r => string.Join(" ", r.Lorem.Words(new Random().Next(1, 10))))
                .RuleFor(r => r.Plot, r => "Series Plot")
                .RuleFor(r => r.EpisodePlot, r => string.Join(" ", r.Lorem.Words(new Random().Next(1, 10))))
                .RuleFor(r => r.MpaaRating, r => "TV/14")
                .RuleFor(r => r.Runtime, r => r.Finance.Amount(0, 999, 2))
                .RuleFor(r => r.EpisodeNumber, r => r.Random.Number(min: 1, max: 100))
                .RuleFor(r => r.SeasonNumber, r => r.Random.Number(min: 1, max: 100))
                .RuleFor(r => r.Codec, r => GenerateString(r, 8))
                .RuleFor(r => r.Resolution, r => GenerateString(r, 16))
                .RuleFor(r => r.Extended, r => GenerateString(r, 16))
                .RuleFor(r => r.ReleaseDate, r => new DateTime(1753, 8, 7))
                .Generate();
        }

        public static IEnumerable<StarRequest> GetStars(int number, PersonType role)
        {
            return new AutoFaker<StarRequest>()
                    .RuleFor(r => r.Role, r => role)
                    .RuleFor(r => r.FirstName, r => r.Person.FirstName)
                    .RuleFor(r => r.MiddleName, r => GenerateString(r, 64))
                    .RuleFor(r => r.LastName, r => r.Person.LastName)
                    .RuleFor(r => r.Suffix, r => r.Name.Suffix())
                    .Generate(number);
        }

        public static IEnumerable<GenreRequest> GetGenres(int number = 1)
        {
            return new AutoFaker<GenreRequest>()
                    .RuleFor(r => r.Name, r => GenerateString(r, 16))
                    .Generate(number);
        }

        public static IEnumerable<RatingRequest> GetRatings(int number = 1)
        {
            return new AutoFaker<RatingRequest>()
                    .RuleFor(r => r.Source, r => GenerateString(r, 28))
                    .RuleFor(r => r.RatingValue, r => r.Finance.Amount(0.01m, 100, 2))
                    .Generate(number);
        }

        private static string GenerateString(Faker faker, int max = 32)
        {
            var fakeString = faker.Random.Words();

            return fakeString.Length <= max
                ? fakeString
                : fakeString.Substring(0, max);
        }
    }
}
