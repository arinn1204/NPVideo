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
using VideoDB.WebApi.Tests.Extensions;
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
            var (tvShow, tvEpisodes) = repository.UpsertTvEpisode(request);

            tvShow.Count().Should().Be(1);
            tvShow.All(a => a.imdb_id == "tt134132").Should().BeTrue();

            tvEpisodes.Count().Should().Be(1);
            tvEpisodes.All(a => a.imdb_id == "tt134133").Should().BeTrue();


            var command = @"SELECT COUNT(*)
FROM video.vw_tv_series
WHERE imdb_id = 'tt134132'";

            using var sqlConnection = new SqlConnection(_config.CreateConnectionString());
            using var sqlCommand = new SqlCommand(command, sqlConnection);

            sqlCommand.Connection.Open();

            var reader = sqlCommand.ExecuteReader();
            reader.Read();
            var rowCount = reader.GetInt32(0);
            sqlCommand.Connection.Close();

            rowCount.Should().Be(1);

            command = @"SELECT COUNT(*)
FROM video.vw_tv_episodes
WHERE imdb_id = 'tt134133'";

            sqlCommand.CommandText = command;
            sqlCommand.Connection.Open();

            reader = sqlCommand.ExecuteReader();
            reader.Read();
            rowCount = reader.GetInt32(0);
            sqlCommand.Connection.Close();

            rowCount.Should().Be(1);

        }

        [Test]
        public void ShouldThrowExceptionWhenRequestIsInvalid()
        {
            var repository = _fixture.Create<TvEpisodeRepository>();
            var request = RequestGenerator.GetTvEpisodeRequest();

            request.Actors
                .First()
                .Modify(gr => gr.FirstName, null);

            Action exception = () => repository.UpsertTvEpisode(request);

            exception.Should()
                .Throw<EvoException>()
                .WithMessage(@"Cannot insert the value NULL into column 'first_name', table '@persons'; column does not allow nulls. INSERT fails.
The data for table-valued parameter ""@persons"" doesn't conform to the table type of the parameter. SQL Server error is: 515, state: 2
The statement has been terminated.");
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
            var (tvShows, tvEpisodes) = repository.GetTvEpisodes();

            tvEpisodes
                .Select(s => s.imdb_id)
                .Distinct()
                .Should()
                .HaveCount(10)
                .And
                .BeEquivalentTo(new[]
                {
                    "tt1","tt2","tt3","tt4","tt5","tt6","tt7","tt8","tt9","tt10"
                });

            tvShows
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
        public void ShouldRetrieveOneEpisodeInDatastore()
        {
            foreach (var id in Enumerable.Range(1, 10))
            {
                var request = RequestGenerator.GetTvEpisodeRequest(100, id);
                Database.AddRequestItem(request, _config);
            }


            var repository = _fixture.Create<TvEpisodeRepository>();
            var (tvShows, tvEpisodes) = repository.GetTvEpisodes("tt1");

            tvEpisodes
                .Select(s => s.imdb_id)
                .Distinct()
                .Should()
                .HaveCount(1)
                .And
                .BeEquivalentTo(new[]
                {
                    "tt1"
                });

            tvShows
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
            var (tvShows, tvEpisodes) = repository.GetTvEpisodes();

            tvEpisodes
                .Select(s => s.imdb_id)
                .Distinct()
                .Should()
                .BeEmpty();

            tvShows
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
                var request = RequestGenerator.GetTvEpisodeRequest(100 + id, id);
                Database.AddRequestItem(request, _config);
            }

            var repository = _fixture.Create<TvEpisodeRepository>();
            var tvSeries = repository.GetTvShows();

            tvSeries
                .Select(s => s.imdb_id)
                .Distinct()
                .Should()
                .BeEquivalentTo(new[] { "tt101", "tt102", "tt103", "tt104", "tt105", "tt106", "tt107", "tt108", "tt109", "tt110" });
        }


        [Test]
        public void ShouldReturnSpecificTvSeriesInDatastore()
        {
            foreach (var id in Enumerable.Range(1, 10))
            {
                var request = RequestGenerator.GetTvEpisodeRequest(100 + id, id);
                Database.AddRequestItem(request, _config);
            }

            var repository = _fixture.Create<TvEpisodeRepository>();
            var tvSeries = repository.GetTvShows("tt101");

            tvSeries
                .Select(s => s.imdb_id)
                .Distinct()
                .Single()
                .Should()
                .Be("tt101");
        }

        [TestCase("VideoId")]
        [TestCase("Plot")]
        [TestCase("Title")]
        [TestCase("MpaaRating")]
        [TestCase("Codec")]
        [TestCase("Resolution")]
        [TestCase("TvEpisodeId")]
        [TestCase("EpisodeName")]
        [TestCase("EpisodePlot")]
        public void ShouldThrowBadRequestExceptionIfStoredProcedureThrowsValidationError(string property)
        {
            var repository = _fixture.Create<TvEpisodeRepository>();
            var request = RequestGenerator.GetTvEpisodeRequest();

            request.GetType()
                .GetProperty(property)
                .SetValue(request, null);

            Action exception = 
                () => repository.UpsertTvEpisode(request);

            exception.Should()
                .Throw<EvoBadRequestException>()
                .WithMessage($"{property} can not be null.");

        }
    }
}
