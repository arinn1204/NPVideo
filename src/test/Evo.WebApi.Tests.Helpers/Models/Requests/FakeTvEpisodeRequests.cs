using AutoBogus;
using Evo.WebApi.Models.Requests;

namespace Evo.WebApi.Tests.Helpers.Models.Requests
{
    public static class FakeTvEpisodeRequests
    {
        public static TvEpisodeRequest CreateTvEpisode(string tvId, string videoId)
        {
            return new AutoFaker<TvEpisodeRequest>()
                .UseSeed(1)
                .RuleFor(r => r.TvEpisodeId, r => tvId)
                .RuleFor(r => r.VideoId, r => videoId)
                .Generate();
        }
    }
}