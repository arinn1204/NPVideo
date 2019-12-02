using AutoBogus;
using AutoFixture;
using AutoFixture.AutoMoq;
using Evo.WebApi.Exceptions;
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
using VideoDB.WebApi.Tests.Integration.Features.Steps.Support;
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
            var request = RequestGenerator.GetTvEpisodeRequest(134132, 134133);
            var videoEntered = repository.UpsertTvEpisode(request);

            videoEntered.videoDataModels.Count().Should().Be(60);
            videoEntered.videoDataModels.All(a => a.imdb_id == "tt134132").Should().BeTrue();

            videoEntered.tvDataModels.Count().Should().Be(60);
            videoEntered.tvDataModels.All(a => a.episode_imdb_id == "tt134133").Should().BeTrue();


            var command = @"SELECT COUNT(*)
FROM video.vw_series
WHERE imdb_id = 'tt134132'";

            using var sqlConnection = new SqlConnection(_config.CreateConnectionString());
            using var sqlCommand = new SqlCommand(command, sqlConnection);

            sqlCommand.Connection.Open();

            var reader = sqlCommand.ExecuteReader();
            reader.Read();
            var rowCount = reader.GetInt32(0);
            sqlCommand.Connection.Close();

            rowCount.Should().Be(60);

            command = @"SELECT COUNT(*)
FROM video.vw_tv_episodes
WHERE episode_imdb_id = 'tt134133'";

            sqlCommand.CommandText = command;
            sqlCommand.Connection.Open();

            reader = sqlCommand.ExecuteReader();
            reader.Read();
            rowCount = reader.GetInt32(0);
            sqlCommand.Connection.Close();

            rowCount.Should().Be(60);

        }

        [Test]
        public void ShouldThrowExceptionWhenRequestIsNotFormattedCorrectly()
        {
            var repository = _fixture.Create<TvEpisodeRepository>();
            var request = RequestGenerator.GetTvEpisodeRequest();
            request.TvEpisodeId = null;
            Action exception = () => repository.UpsertTvEpisode(request);

            exception.Should()
                .Throw<EvoException>()
                .WithMessage("Procedure or function 'usp_add_tv_episode' expects parameter '@episode_imdb_id', which was not supplied.");
        }

        [Test]
        public void ShouldRetrieveAllEpisodesInDatastore()
        {
            foreach (var id in Enumerable.Range(1, 10))
            {
                var request = RequestGenerator.GetTvEpisodeRequest(100, id);
                Database.AddRequestItem(request, _config);
            }


            var repository = _fixture.Create<TvEpisodeRepository>();
            var episodes = repository.GetTvEpisodes();

            episodes
                .tvDataModels
                .Select(s => s.episode_imdb_id)
                .Distinct()
                .Should()
                .HaveCount(10)
                .And
                .BeEquivalentTo(new[]
                {
                    "tt1","tt2","tt3","tt4","tt5","tt6","tt7","tt8","tt9","tt10"
                });

            episodes
                .videoDataModels
                .Select(s => s.imdb_id)
                .Distinct()
                .Should()
                .HaveCount(1)
                .And
                .BeEquivalentTo(new[]
                {
                    "tt100"
                });
        }

        [Test]
        public void ShouldReturnEmptyEnumerableIfNoEpisodesInDataStore()
        {
            var repository = _fixture.Create<TvEpisodeRepository>();
            var episodes = repository.GetTvEpisodes();

            episodes
                .tvDataModels
                .Select(s => s.episode_imdb_id)
                .Distinct()
                .Should()
                .BeEmpty();

            episodes
                .videoDataModels
                .Select(s => s.imdb_id)
                .Distinct()
                .Should()
                .BeEmpty();
        }

        [Test]
        public void ShouldReturnEmptyEnumerableIfNoSeriesInDataStore()
        {
            var repository = _fixture.Create<TvEpisodeRepository>();
            var tvSeries = repository.GetTvShows();

            tvSeries
                .Should()
                .BeEmpty();
        }

        [Test]
        public void ShouldReturnAllTvSeriesInDatastore()
        {
            foreach (var id in Enumerable.Range(1, 10))
            {
                var request = RequestGenerator.GetTvEpisodeRequest(100, id);
                Database.AddRequestItem(request, _config);
            }

            var repository = _fixture.Create<TvEpisodeRepository>();
            var tvSeries = repository.GetTvShows();

            tvSeries
                .Select(s => s.imdb_id)
                .Distinct()
                .Single()
                .Should()
                .Be("tt100");
        }

    }
}
