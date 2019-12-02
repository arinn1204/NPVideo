using BoDi;
using Evo.WebApi.Models.Requests;
using Evo.WebApi.Models.ViewModels;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using VideoDB.WebApi.Models.ViewModels;

namespace VideoDB.WebApi.Tests.Integration.Features.Steps.Assertions
{
    [Binding]
    public class VideoAssertions
    {
        private readonly HttpResponseMessage _response;
        private readonly object _request;

        public VideoAssertions(HttpResponseMessage response, IObjectContainer container)
        {
            _response = response;
            _request = container.Resolve<object>(name: "RequestBody");
        }

        [Then(@"the user receives a copy of the new (movie|tv episode)")]
        public async Task ThenTheUserReceivesACopyOfTheNewVideo(string typeOfMedia)
        {
            var contentString = await _response.Content.ReadAsStringAsync();

            switch (typeOfMedia.ToUpperInvariant())
            {
                case "MOVIE":
                    var videoContent =
                        JsonConvert.DeserializeObject<IEnumerable<MovieViewModel>>(
                            contentString);

                    videoContent
                        .Single()
                        .VideoId
                        .Should()
                        .BeEquivalentTo((_request as MovieRequest).VideoId);
                    break;
                case "TV EPISODE":
                    var tvEpisodeContent = JsonConvert.DeserializeObject<TvEpisodeViewModel>(contentString);
                    tvEpisodeContent
                        .Series
                        .VideoId
                        .Should()
                        .BeEquivalentTo((_request as TvEpisodeRequest).VideoId);

                    tvEpisodeContent
                        .Episode
                        .Single()
                        .VideoId
                        .Should()
                        .BeEquivalentTo((_request as TvEpisodeRequest).TvEpisodeId);
                    break;
            }
        }

        [Then(@"the user is shown the specific (movie|tv episode|show)")]
        public async Task ThenTheUserIsShownTheSpecificMovie(string typeOfMedia)
        {
            var contentString = await _response.Content.ReadAsStringAsync();

            switch (typeOfMedia.ToUpperInvariant())
            {
                case "MOVIE":
                    var videoContent =
                        JsonConvert.DeserializeObject<IEnumerable<MovieViewModel>>(
                            contentString);

                    videoContent.Select(s => s.VideoId)
                        .Single()
                        .Should()
                        .Be("tt1005");

                    break;
                case "TV EPISODE":
                    var tvEpisodeContent =
                        JsonConvert.DeserializeObject<TvEpisodeViewModel>(
                            contentString);

                    tvEpisodeContent.Series.VideoId.Should().Be("tt10000");
                    tvEpisodeContent
                        .Episode
                        .Single()
                        .Should()
                        .BeEquivalentTo(
                            new TvEpisode { VideoId = "tt1005" },
                            opt => opt.ExcludingMissingMembers());

                    break;
                case "SHOW":
                    var tvShowsContent =
                        JsonConvert.DeserializeObject<SeriesViewModel>(
                            contentString);

                    tvShowsContent
                        .VideoId
                        .Should()
                        .Be("tt10000");
                    break;
            }
        }


        [Then(@"the user is shown all the existing (movie|tv episode|show)s")]
        public async Task ThenTheUserIsShownAllTheExistingMovie(string typeOfMedia)
        {
            var contentString = await _response.Content.ReadAsStringAsync();

            switch (typeOfMedia.ToUpperInvariant())
            {
                case "MOVIE":
                    var videoContent =
                        JsonConvert.DeserializeObject<IEnumerable<MovieViewModel>>(
                            contentString);

                    videoContent.Should().HaveCount(10);

                    videoContent.Select(s => s.VideoId)
                        .Union(Enumerable.Range(1, 10).Select(s => $"tt{s}"))
                        .Distinct()
                        .Should()
                        .HaveCount(10);

                    break;
                case "TV EPISODE":
                    var tvEpisodeContent = 
                        JsonConvert.DeserializeObject< IEnumerable<TvEpisodeViewModel>>(
                            contentString);

                    tvEpisodeContent.Select(s => s.Series).Should().HaveCount(1);
                    tvEpisodeContent.SelectMany(s => s.Episode)
                        .Should()
                        .HaveCount(10);

                    tvEpisodeContent.SelectMany(s => s.Episode)
                        .Select(s => s.VideoId)
                        .Union(Enumerable.Range(1, 10).Select(s => $"tt{s}"))
                        .Distinct()
                        .Should()
                        .HaveCount(10);

                    break;
                case "SHOW":
                    var tvShowsContent =
                        JsonConvert.DeserializeObject<IEnumerable<SeriesViewModel>>(
                            contentString);

                    tvShowsContent
                        .Should()
                        .HaveCount(1);
                    break;
            }
        }
    }
}
