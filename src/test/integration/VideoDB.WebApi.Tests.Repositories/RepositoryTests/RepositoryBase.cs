using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using VideoDB.WebApi.Extensions;

namespace VideoDB.WebApi.Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class RepositoryBase
    {
        protected IConfiguration _config;
        protected Fixture _fixture;
        protected string _database = "noblepanther_test";

        [OneTimeSetUp]
        public void DbSetup()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _database = string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("db_catalog"))
                ? _database
                : Environment.GetEnvironmentVariable("db_catalog");
        }

        [SetUp]
        public void DeleteFromTables()
        {
            using var sqlConnection = new SqlConnection(_config.CreateConnectionString());
            using var command = new SqlCommand($@"
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

            DBCC CHECKIDENT('{_database}.video.videos', RESEED, 0);
            DBCC CHECKIDENT('{_database}.video.tv_episodes', RESEED, 0);
            DBCC CHECKIDENT('{_database}.video.genres', RESEED, 0);
            DBCC CHECKIDENT('{_database}.video.ratings', RESEED, 0);
            DBCC CHECKIDENT('{_database}.video.persons', RESEED, 0);
            DBCC CHECKIDENT('{_database}.video.roles', RESEED, 0);
            ", sqlConnection);

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
            _fixture.Inject<IConfiguration>(_config);
        }
    }
}