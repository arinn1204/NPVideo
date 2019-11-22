using System;
using System.Net.Http;
using BoDi;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace Evo.WebApi.Tests.Integration.Features.Steps.Support
{
    [Binding]
    public class Hooks
    {
        [BeforeTestRun]
        public static void TestRunSetup(IObjectContainer container)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true)
                .AddJsonFile($"appsettings.Test.Integration.json", true)
                .Build();

            var factory = new EvoApplicationFactory<Startup>(configuration);

            container.RegisterInstanceAs(factory);
            container.RegisterInstanceAs<IConfiguration>(configuration);
        }

        [BeforeFeature]
        public static void BeforeFeature(IObjectContainer container, EvoApplicationFactory<Startup> appFactory)
        {
            var client = appFactory.CreateClient();
            container.RegisterInstanceAs(client);
        }

        [AfterFeature]
        public static void AfterFeature(IObjectContainer container)
        {
            var client = container.Resolve<HttpClient>();
            client.Dispose();
        }

        [AfterTestRun]
        public static void AfterTestRun(IObjectContainer container)
        {
            var factory = container.Resolve<EvoApplicationFactory<Startup>>();
            var connection = container.Resolve<SqliteConnection>();
            connection.Close();
            connection.Dispose();
            factory.Dispose();
        }
    }
}