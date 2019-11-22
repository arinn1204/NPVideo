using Evo.WebApi.Models.DataModel;
using Evo.WebApi.Models.Requests;
using Evo.WebApi.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VideoDB.WebApi.Tests.Integration.RepositoryTests
{
    [TestFixture]
    class VideoRepositoryTests
    {
        private SqlConnection _sqlConnection;

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
        }

        [Test]
        public async Task ShouldInsertVideoWhenCalled()
        {
        }
    }
}

namespace VideoDB.WebApi.Repositories
{
    class VideoRepository : IVideoRepository
    {
        public Task<IEnumerable<TvEpisodeDataModel>> UpsertTvEpisode(TvEpisodeRequest video)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VideoDataModel>> UpsertVideo(VideoRequest video)
        {
            throw new NotImplementedException();
        }
    }
}
