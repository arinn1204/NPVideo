using AutoBogus;
using AutoFixture;
using AutoFixture.AutoMoq;
using Bogus;
using Evo.WebApi.Models.Enums;
using Evo.WebApi.Models.Requests;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Linq;
using VideoDB.WebApi.Extensions;
using VideoDB.WebApi.Repositories;

namespace VideoDB.WebApi.Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class VideoRepositoryTests
    {
        private IConfigurationRoot _config;
        private Fixture _fixture;
        private string _database = "noblepanther_test";

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
            var command = new SqlCommand($@"
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
            command.Dispose();

            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
            _fixture.Inject<IConfiguration>(_config);
        }

        [Test]
        public void ShouldInsertVideoWhenCalled()
        {
            var repository = _fixture.Create<VideoRepository>();
            var request = GetVideoRequest();
            var videoEntered = repository.UpsertVideo(request);

            videoEntered.Count().Should().Be(60);
            videoEntered.All(a => a.imdb_id == "tt134132").Should().BeTrue();

            var command = @"SELECT video_id
FROM video.videos
WHERE imdb_id = 'tt134132'";

            using var sqlConnection = new SqlConnection(_config.CreateConnectionString());
            using var sqlCommand = new SqlCommand(command, sqlConnection);
            
            sqlCommand.Connection.Open();

            var reader = sqlCommand.ExecuteReader();
            reader.HasRows.Should().BeTrue();
            
            sqlCommand.Connection.Close();
        }

        private VideoRequest GetVideoRequest()
        {
            return new AutoFaker<VideoRequest>()
                .RuleFor(r => r.Actors, r1 => new AutoFaker<StarRequest>()
                    .RuleFor(r => r.Role, r => PersonType.Actor)
                    .RuleFor(r => r.FirstName, r => r.Person.FirstName)
                    .RuleFor(r => r.MiddleName, r => r.Person.FirstName)
                    .RuleFor(r => r.LastName, r => r.Person.LastName)
                    .RuleFor(r => r.Suffix, r => r.Name.Suffix())
                    .Generate(3))
                .RuleFor(r => r.Directors, r1 => new AutoFaker<StarRequest>()
                    .RuleFor(r => r.Role, r => PersonType.Director)
                    .RuleFor(r => r.FirstName, r => r.Person.FirstName)
                    .RuleFor(r => r.MiddleName, r => r.Person.FirstName)
                    .RuleFor(r => r.LastName, r => r.Person.LastName)
                    .RuleFor(r => r.Suffix, r => r.Name.Suffix())
                    .Generate(1))
                .RuleFor(r => r.Writers, r1 => new AutoFaker<StarRequest>()
                    .RuleFor(r => r.Role, r => PersonType.Writer)
                    .RuleFor(r => r.FirstName, r => r.Person.FirstName)
                    .RuleFor(r => r.MiddleName, r => r.Person.FirstName)
                    .RuleFor(r => r.LastName, r => r.Person.LastName)
                    .RuleFor(r => r.Suffix, r => r.Name.Suffix())
                    .Generate(3))
                .RuleFor(r => r.Producers, r1 => new AutoFaker<StarRequest>()
                    .RuleFor(r => r.Role, r => PersonType.Producer)
                    .RuleFor(r => r.FirstName, r => r.Person.FirstName)
                    .RuleFor(r => r.MiddleName, r => r.Person.FirstName)
                    .RuleFor(r => r.LastName, r => r.Person.LastName)
                    .RuleFor(r => r.Suffix, r => r.Name.Suffix())
                    .Generate(3))
                .RuleFor(r => r.Genres, r1 => new AutoFaker<GenreRequest>()
                    .RuleFor(r => r.Name, r => GenerateString(r, 16))
                    .Generate(3))
                .RuleFor(r => r.Ratings, r1 => new AutoFaker<RatingRequest>()
                    .RuleFor(r => r.Source, r => GenerateString(r, 28))
                    .RuleFor(r => r.RatingValue, r => r.Finance.Amount(0, 100, 2))
                    .Generate(2))
                .RuleFor(r => r.Title, r => string.Join(" ", r.Lorem.Words(new Random().Next(0, 10000))))
                .RuleFor(r => r.MpaaRating, r => GenerateString(r, 7))
                .RuleFor(r => r.Plot, r => string.Join(" ", r.Lorem.Words(new Random().Next(0, 100))))
                .RuleFor(r => r.Runtime, r => r.Finance.Amount(0, 999, 2))
                .RuleFor(r => r.Type, r => VideoType.Movie)
                .RuleFor(r => r.VideoId, r => "tt134132")
                .Generate();
        }

        private string GenerateString(Faker faker, int max = 32)
        {
            var fakeString = faker.Random.Words();

            return fakeString.Length <= max
                ? fakeString
                : fakeString.Substring(0, max);
        }
    }
}