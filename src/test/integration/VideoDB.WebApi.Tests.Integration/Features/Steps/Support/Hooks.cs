using System;
using System.Net.Http;
using BoDi;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace Evo.WebApi.Tests.Integration.Features.Steps.Support
{
    [Binding]
    public class Hooks
    {
        [BeforeTestRun(Order = 0)]
        public static void TestRunSetup(IObjectContainer container)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true)
                .Build();

            var factory = new WebApplicationFactory<Startup>();

            container.RegisterInstanceAs(factory);
            container.RegisterInstanceAs<IConfiguration>(configuration);
        }

        [BeforeTestRun]
        public static void BeforeFeature(IObjectContainer container, WebApplicationFactory<Startup> appFactory)
        {
            var client = appFactory.CreateClient(
                new WebApplicationFactoryClientOptions()
            {
                    BaseAddress = new Uri("http://localhost:8080")
            });
            container.RegisterInstanceAs(client);
        }

        [AfterTestRun]
        public static void AfterTestRun(IObjectContainer container)
        {
            var client = container.Resolve<HttpClient>();
            client.Dispose();
            var factory = container.Resolve<WebApplicationFactory<Startup>>();
            factory.Dispose();
        }
    }
}