using System.Collections.Generic;
using AutoBogus;
using Evo.WebApi.Models.Requests;

namespace Evo.WebApi.Tests.Helpers.Models.Requests
{
    public static class FakeVideoRequests
    {
        public static VideoRequest CreateVideoRequest(string id)
        {
            return new AutoFaker<VideoRequest>()
                .UseSeed(1)
                .RuleFor(r => r.VideoId, r => id)
                .RuleFor(r => r.Actors, r => CreateStarRequest(3))
                .RuleFor(r => r.Writers, r => CreateStarRequest(3))
                .RuleFor(r => r.Directors, r => CreateStarRequest(3))
                .RuleFor(r => r.Producers, r => CreateStarRequest(3))
                .RuleFor(r => r.Genres, r => CreateGenreRequest(3))
                .RuleFor(r => r.Ratings, r => CreateRatingRequest(2))
                .Generate();
        }

        public static IEnumerable<StarRequest> CreateStarRequest(int count)
        {
            return new AutoFaker<StarRequest>()
                .Generate(count);
        }

        public static IEnumerable<GenreRequest> CreateGenreRequest(int count)
        {
            return new AutoFaker<GenreRequest>()
                .Generate(count);
        }

        public static IEnumerable<RatingRequest> CreateRatingRequest(int count)
        {
            return new AutoFaker<RatingRequest>()
                .Generate(count);
        }
    }
}