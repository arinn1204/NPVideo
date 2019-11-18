using System;
using System.Net;
using System.Net.Http;

namespace Evo.WebApi.Tests.Integration.Models
{
    public class Evo
    {
        public Evo()
        {
            BaseAddress = new Uri("http://localhost");
        }

        public HttpRequestMessage RequestMessage { get; set; }
        public string Response { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public Uri BaseAddress { get; set; }
    }
}