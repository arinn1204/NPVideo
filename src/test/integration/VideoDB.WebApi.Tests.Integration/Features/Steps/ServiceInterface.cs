using BoDi;
using System;
using System.Net.Http;
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
            var message = _container.Resolve<HttpRequestMessage>();
            message.Method = GetMethod(operation.Trim().Trim('s'));
            message.RequestUri = new Uri("http://localhost:8080/api/videos");

            var response = await _client.SendAsync(message);

            if (!response.IsSuccessStatusCode) 
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            _container.RegisterInstanceAs(response);
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
