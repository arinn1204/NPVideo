using System;
using System.Net.Http;
using BoDi;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;
using VideoDB.WebApi.Extensions;

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
            var hooks = new Hooks();

            hooks.CleanDatabase(configuration);
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

        [BeforeScenario("@clean")]
        public void CleanDatabase(IConfiguration configuration) 
        {
            var database = string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("db_catalog"))
                ? "noblepanther_test"
                : Environment.GetEnvironmentVariable("db_catalog");

            var command = $@"
                DELETE FROM video.genre_videos;
                DELETE FROM video.person_videos;
                DELETE FROM video.person_roles;
                DELETE FROM video.genre_tv_episodes;
                DELETE FROM video.person_tv_episodes;

                DELETE FROM video.persons;
                DELETE FROM video.roles;
                DELETE FROM video.genres;
                DELETE FROM video.ratings;
                DELETE FROM video.tv_episodes;
                DELETE FROM video.videos;

                DBCC CHECKIDENT('{database}.video.videos', RESEED, 0);
                DBCC CHECKIDENT('{database}.video.tv_episodes', RESEED, 0);
                DBCC CHECKIDENT('{database}.video.genres', RESEED, 0);
                DBCC CHECKIDENT('{database}.video.ratings', RESEED, 0);
                DBCC CHECKIDENT('{database}.video.persons', RESEED, 0);
                DBCC CHECKIDENT('{database}.video.roles', RESEED, 0);
                ";

            var connectionString = configuration.CreateConnectionString();
            using var sqlConnection = new SqlConnection(connectionString);
            using var sqlCommand = new SqlCommand(command, sqlConnection);

            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();
        }
    }
}