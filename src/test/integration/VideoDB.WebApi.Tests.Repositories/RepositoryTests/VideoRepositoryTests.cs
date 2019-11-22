using AutoBogus;
using AutoFixture;
using AutoFixture.AutoMoq;
using Evo.WebApi.Models.DataModel;
using Evo.WebApi.Models.Enums;
using Evo.WebApi.Models.Requests;
using Evo.WebApi.Repositories.Interfaces;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoDB.WebApi.Repositories;

namespace VideoDB.WebApi.Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class VideoRepositoryTests
    {
        private SqlConnection _sqlConnection;
        private Fixture _fixture;

        [OneTimeSetUp]
        public void DbSetup()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _sqlConnection = new SqlConnection(config.GetConnectionString("npdb"));
        }

        [SetUp]
        public void DeleteFromTables()
        {
            var command = new SqlCommand(@"
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

            DBCC CHECKIDENT('noblepanther_dev.video.videos', RESEED, 0);
            DBCC CHECKIDENT('noblepanther_dev.video.tv_episodes', RESEED, 0);
            DBCC CHECKIDENT('noblepanther_dev.video.genres', RESEED, 0);
            DBCC CHECKIDENT('noblepanther_dev.video.ratings', RESEED, 0);
            DBCC CHECKIDENT('noblepanther_dev.video.persons', RESEED, 0);
            DBCC CHECKIDENT('noblepanther_dev.video.roles', RESEED, 0);
            ", _sqlConnection);

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
            command.Dispose();

            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
            _fixture.Inject(_sqlConnection);
        }

        [Test]
        public void ShouldInsertVideoWhenCalled()
        {
            var repository = _fixture.Create<VideoRepository>();
            var request = GetVideoRequest();
            var videoEntered = repository.UpsertVideo(request);

            videoEntered.Count().Should().Be(15);
            videoEntered.All(a => a.imdb_id == "tt134132").Should().BeTrue();
        }

        private VideoRequest GetVideoRequest()
        {
            return new VideoRequest()
            {
                Actors = new AutoFaker<StarRequest>().RuleFor(r => r.Role, r => PersonType.Actor).Generate(3),
                Directors = new AutoFaker<StarRequest>().RuleFor(r => r.Role, r => PersonType.Director).Generate(1),
                Writers = new AutoFaker<StarRequest>().RuleFor(r => r.Role, r => PersonType.Writer).Generate(3),
                Producers = new AutoFaker<StarRequest>().RuleFor(r => r.Role, r => PersonType.Producer).Generate(3),
                Genres = new AutoFaker<GenreRequest>().Generate(3),
                Ratings = new AutoFaker<RatingRequest>().Generate(2),
                MpaaRating = "R",
                Plot = "Some plot",
                ReleaseDate = DateTime.Today,
                Runtime = 120.5m,
                Title = "The one movie that had a thing",
                Type = VideoType.Video,
                VideoId = "tt134132"
            };
        }
    }
}