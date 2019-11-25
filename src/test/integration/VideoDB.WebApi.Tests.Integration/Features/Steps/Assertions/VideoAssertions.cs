using Evo.WebApi.Models.ViewModels;
using FluentAssertions;
using Newtonsoft.Json;
using System;
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

        public VideoAssertions(HttpResponseMessage response)
        {
            _response = response;
        }

        [Then(@"the user receives a copy of the new video")]
        public async Task ThenTheUserReceivesACopyOfTheNewVideo()
        {
            var contentString = await _response.Content.ReadAsStringAsync();
            var content = 
                JsonConvert.DeserializeObject<VideoViewModel>(
                    contentString);

            content.VideoId.Should().NotBeNullOrEmpty();
        }
        
        [Then(@"the user receives nothing")]
        public async Task ThenTheUserReceivesNothing()
        {
            _response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            (await _response.Content.ReadAsStringAsync()).Should().BeEmpty();
        }
    }
}
