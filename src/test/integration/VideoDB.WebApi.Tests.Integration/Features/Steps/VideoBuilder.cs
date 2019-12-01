using BoDi;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TechTalk.SpecFlow;
using VideoDB.WebApi.Tests.Helpers;
using VideoDB.WebApi.Tests.Integration.Features.Steps.Support;

namespace VideoDB.WebApi.Tests.Integration.Features.Steps
{
    [Binding]
    public class VideoBuilder
    {
        private readonly IObjectContainer _container;

        public VideoBuilder(IObjectContainer container)
        {
            _container = container;
        }

        [Given(@"a new (.*)")]
        public void GivenANewVideo(string typeOfContent)
        {
            var request = typeOfContent.ToUpperInvariant() switch
            {
                "VIDEO" => RequestGenerator.GetVideoRequest(),
                "TV EPISODE" => RequestGenerator.GetTvEpisodeRequest(),
                _ => throw new Exception($"{typeOfContent} is not currently supported.")
            };
                
            var httpRequest = new HttpRequestMessage()
            {
                Content = new StringContent(
                    JsonConvert.SerializeObject(request),
                    Encoding.UTF8,
                    "application/json")
            };

            _container.RegisterInstanceAs(httpRequest);
        }

        [Given(@"a (.*) already exists in the record")]
        public void GivenAVideoAlreadyExistsInTheRecord(string typeOfContent)
        {
            var request = typeOfContent.ToUpperInvariant() switch
            {
                "VIDEO" => RequestGenerator.GetVideoRequest(),
                "TV EPISODE" => RequestGenerator.GetTvEpisodeRequest(),
                _ => throw new Exception($"{typeOfContent} is not currently supported.")
            };

            Database.AddRequestItem(request, _container.Resolve<IConfiguration>());

            var httpRequest = new HttpRequestMessage()
            {
                Content = new StringContent(
                    JsonConvert.SerializeObject(request),
                    Encoding.UTF8,
                    "application/json")
            };

            _container.RegisterInstanceAs(httpRequest);
        }

    }
}
