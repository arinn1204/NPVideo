using BoDi;
using Evo.WebApi.Exceptions;
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

        [When(@"the user (create|update)s an? (?:new|existing) (movie|tv episode)")]
        public async Task WhenTheUserCreatesANewVideo(string operation, string mediaType)
        {
            string path = BuildPath(mediaType);

            await CallService(operation, path);
        }

        [When(@"the user views all existing (movie|tv episode|show)s")]
        public async Task WhenTheUserChecksExistingMovie(string mediaType)
        {
            var path = BuildPath(mediaType);
            await CallService("views", path);
        }

        [When(@"the user views the existing (movie|tv episode|show)")]
        public async Task WhenTheUserViewsTheExistingMovie(string mediaType)
        {
            var path = BuildPath(mediaType);
            await CallService("views", path);
        }


        private string BuildPath(string mediaType)
        {
            return mediaType.ToUpperInvariant() switch
            {
                "MOVIE" => "videos/movies",
                "TV EPISODE" => "videos/tvEpisodes",
                "SHOW" => "videos/tvEpisodes/shows",
                _ => throw new EvoException($"'{mediaType}' is not supported.")
            };
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

            if (_container.IsRegistered<object>("RequestID"))
            {
                endpoint = $"{endpoint}/{_container.Resolve<object>("RequestID") as string}";
            }

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
