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
        
        [Then(@"the user receives nothing")]
        public async Task ThenTheUserReceivesNothing()
        {
            _response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            (await _response.Content.ReadAsStringAsync()).Should().BeEmpty();
        }
    }
}
