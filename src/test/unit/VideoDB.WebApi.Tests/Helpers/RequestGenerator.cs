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
        public static VideoRequest GetVideoRequest(string id = "tt134132")
        {
            return new AutoFaker<VideoRequest>()
                .RuleFor(r => r.Actors, r => GetStars(3, PersonType.Actor))
                .RuleFor(r => r.Directors, r => GetStars(1, PersonType.Director))
                .RuleFor(r => r.Writers, r => GetStars(3, PersonType.Writer))
                .RuleFor(r => r.Producers, r => GetStars(3, PersonType.Producer))
                .RuleFor(r => r.Genres, r => GetGenres(3))
                .RuleFor(r => r.Ratings, r => GetRatings(2))
                .RuleFor(r => r.Title, r => string.Join(" ", r.Lorem.Words(new Random().Next(0, 10000))))
                .RuleFor(r => r.MpaaRating, r => GenerateString(r, 7))
                .RuleFor(r => r.Plot, r => string.Join(" ", r.Lorem.Words(new Random().Next(0, 100))))
                .RuleFor(r => r.Runtime, r => r.Finance.Amount(0, 999, 2))
                .RuleFor(r => r.Type, r => VideoType.Movie)
                .RuleFor(r => r.VideoId, r => id)
                .Generate();
        }

        public static TvEpisodeRequest GetTvEpisodeRequest(string videoId = "tt134132", string tvepisodeId = "tt134133")
        {
            return new AutoFaker<TvEpisodeRequest>()
                .RuleFor(r => r.Actors, r => GetStars(3, PersonType.Actor))
                .RuleFor(r => r.Directors, r => GetStars(1, PersonType.Director))
                .RuleFor(r => r.Writers, r => GetStars(3, PersonType.Writer))
                .RuleFor(r => r.Producers, r => GetStars(3, PersonType.Producer))
                .RuleFor(r => r.Genres, r => GetGenres(3))
                .RuleFor(r => r.Ratings, r => GetRatings(2))
                .RuleFor(r => r.VideoId, r => videoId)
                .RuleFor(r => r.TvEpisodeId, r => tvepisodeId)
                .RuleFor(r => r.Title, r => string.Join(" ", r.Lorem.Words(new Random().Next(0, 10))))
                .RuleFor(r => r.EpisodeName, r => string.Join(" ", r.Lorem.Words(new Random().Next(0, 10))))
                .RuleFor(r => r.Plot, r => string.Join(" ", r.Lorem.Words(new Random().Next(0, 10))))
                .RuleFor(r => r.EpisodePlot, r => string.Join(" ", r.Lorem.Words(new Random().Next(0, 10))))
                .RuleFor(r => r.MpaaRating, r => GenerateString(r, 7))
                .RuleFor(r => r.Runtime, r => r.Finance.Amount(0, 999, 2))
                .RuleFor(r => r.EpisodeNumber, r => r.Random.Number())
                .RuleFor(r => r.SeasonNumber, r => r.Random.Number());
        }

        private static IEnumerable<StarRequest> GetStars(int number, PersonType role)
        {
            return new AutoFaker<StarRequest>()
                    .RuleFor(r => r.Role, r => role)
                    .RuleFor(r => r.FirstName, r => r.Person.FirstName)
                    .RuleFor(r => r.MiddleName, r => r.Person.FirstName)
                    .RuleFor(r => r.LastName, r => r.Person.LastName)
                    .RuleFor(r => r.Suffix, r => r.Name.Suffix())
                    .Generate(number);
        }

        private static IEnumerable<GenreRequest> GetGenres(int number = 1)
        {
            return new AutoFaker<GenreRequest>()
                    .RuleFor(r => r.Name, r => GenerateString(r, 16))
                    .Generate(number);
        }

        private static IEnumerable<RatingRequest> GetRatings(int number = 1)
        {
            return new AutoFaker<RatingRequest>()
                    .RuleFor(r => r.Source, r => GenerateString(r, 28))
                    .RuleFor(r => r.RatingValue, r => r.Finance.Amount(0, 100, 2))
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
