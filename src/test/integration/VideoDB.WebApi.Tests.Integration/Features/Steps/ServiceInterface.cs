﻿using BoDi;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace VideoDB.WebApi.Tests.Integration.Features.Steps
{
    [Binding]
    public class ServiceInterface
    {
        private readonly IObjectContainer _container;
        private readonly HttpClient _client;

        public ServiceInterface(IObjectContainer container)
        {
            _container = container;
            _client = container.Resolve<HttpClient>();
        }

        [When(@"the user (.*) an? (?:new|existing)\s?video")]
        public async Task WhenTheUserCreatesANewVideo(string operation)
        {
            await CallService(operation, "videos");
        }

        [When(@"the user (.*) an? (?:new|existing) tv episode")]
        public async Task WhenTheUserCreatesANewTvEpisode(string operation)
        {
            await CallService(operation, "videos/tvEpisodes");
        }

        private async Task CallService(string operation, string endpoint)
        {
            HttpRequestMessage message = BuildRequest(operation, endpoint);

            var response = await _client.SendAsync(message);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            _container.RegisterInstanceAs(response);
        }

        private HttpRequestMessage BuildRequest(string operation, string endpoint)
        {
            var contentBody = _container.Resolve<object>(name: "RequestBody");
            var contentString = JsonConvert.SerializeObject(contentBody);
            var message = new HttpRequestMessage()
            {
                Method = GetMethod(operation.Trim().Trim('s')),
                RequestUri = new Uri($"http://localhost:8080/api/{endpoint}"),
                Content = new StringContent(contentString, Encoding.UTF8, "application/json")
        };
            return message;
        }


        private HttpMethod GetMethod(string operation)
        {
            return operation switch
            {
                "create" => HttpMethod.Put,
                "update" => HttpMethod.Put,
                _ => HttpMethod.Get,
            };
        }
    }
}
