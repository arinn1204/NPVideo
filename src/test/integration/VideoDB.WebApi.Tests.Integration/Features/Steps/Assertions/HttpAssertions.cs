using BoDi;
using FluentAssertions;
using System;
using System.Net;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace VideoDB.WebApi.Tests.Integration.Features.Steps.Assertions
{
    [Binding]
    public class HttpAssertions
    {
        private readonly HttpResponseMessage _response;

        public HttpAssertions(HttpResponseMessage response)
        {
            _response = response;
        }

        [Then(@"the user is told that it (?:is|was) (.*)")]
        public void ThenTheUserIsAlertedThatItIsCreated(string option)
        {
            var statusCode = GetCode(option.ToUpperInvariant());

            _response.StatusCode.Should().Be(statusCode);
        }
        
        private HttpStatusCode GetCode(string option)
        {
            return option switch
            {
                "CREATED" => HttpStatusCode.Created,
                "SUCCESSFUL" => HttpStatusCode.OK,
                "NO CONTENT" => HttpStatusCode.NoContent,
                _ => HttpStatusCode.Forbidden,
            };
        }
    }
}
