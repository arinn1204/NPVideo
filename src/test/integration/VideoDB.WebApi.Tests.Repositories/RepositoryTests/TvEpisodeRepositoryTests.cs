using AutoBogus;
using AutoFixture;
using AutoFixture.AutoMoq;
using Evo.WebApi.Models.Requests;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoDB.WebApi.Extensions;
using VideoDB.WebApi.Repositories;
using VideoDB.WebApi.Tests.Helpers;
using VideoDB.WebApi.Tests.Integration.RepositoryTests;

namespace VideoDB.WebApi.Tests.Repositories.RepositoryTests
{
    [TestFixture]
    public class TvEpisodeRepositoryTests : RepositoryBase
    {
        [Test]
        public void ShouldInsertTvEpisodeAndSeries()
        {
            var repository = _fixture.Create<TvEpisodeRepository>();
            var request = RequestGenerator.GetTvEpisodeRequest();
            var videoEntered = repository.UpsertTvEpisode(request);

            videoEntered.videoDataModels.Count().Should().Be(60);
            videoEntered.videoDataModels.All(a => a.imdb_id == "tt134132").Should().BeTrue();

            var command = @"SELECT COUNT(*)
FROM video.vw_movies
WHERE imdb_id = 'tt134132'";

            using var sqlConnection = new SqlConnection(_config.CreateConnectionString());
            using var sqlCommand = new SqlCommand(command, sqlConnection);

            sqlCommand.Connection.Open();

            var reader = sqlCommand.ExecuteReader();
            reader.Read();
            var rowCount = reader.GetInt32(0);
            sqlCommand.Connection.Close();

            rowCount.Should().Be(60);


            videoEntered.tvDataModels.Count().Should().Be(60);
            videoEntered.tvDataModels.All(a => a.episode_imdb_id == "tt134133").Should().BeTrue();

            command = @"SELECT COUNT(*)
FROM video.vw_tv_episodes
WHERE imdb_id = 'tt134133'";

            sqlCommand.CommandText = command;
            sqlCommand.Connection.Open();

            reader = sqlCommand.ExecuteReader();
            reader.Read();
            rowCount = reader.GetInt32(0);
            sqlCommand.Connection.Close();

            rowCount.Should().Be(60);

        }

    }
}
