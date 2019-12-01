using AutoFixture;
using Bogus;
using Evo.WebApi.Exceptions;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using NUnit.Framework;
using System;
using System.Linq;
using VideoDB.WebApi.Extensions;
using VideoDB.WebApi.Repositories;
using VideoDB.WebApi.Tests.Extensions;
using VideoDB.WebApi.Tests.Helpers;

namespace VideoDB.WebApi.Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class VideoRepositoryTests : RepositoryBase
    {

        [Test]
        public void ShouldInsertVideo()
        {
            var repository = _fixture.Create<MovieRepository>();
            var request = RequestGenerator.GetMovieRequest(134132);
            var videoEntered = repository.UpsertMovie(request);

            videoEntered.Count().Should().Be(60);
            videoEntered.All(a => a.imdb_id == "tt134132").Should().BeTrue();

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
        }

        [Test]
        public void ShouldThrowExceptionWhenRequestIsInvalid()
        {
            var repository = _fixture.Create<MovieRepository>();
            var request = RequestGenerator.GetMovieRequest();

            request.Actors
                .First()
                .Modify(gr => gr.FirstName, null);

            Action exception = () => repository.UpsertMovie(request);

            exception.Should()
                .Throw<EvoException>()
                .WithMessage(@"Cannot insert the value NULL into column 'first_name', table '@persons'; column does not allow nulls. INSERT fails.
The data for table-valued parameter ""@persons"" doesn't conform to the table type of the parameter. SQL Server error is: 515, state: 2
The statement has been terminated.");
        }

        [Test]
        public void ShouldRetrieveAllVideosInDatastore()
        {
            foreach (var id in Enumerable.Range(1, 10))
            {
                var request = RequestGenerator.GetMovieRequest(id);
                Features.Steps.Support.Database.AddRequestItem(request, _config);
            }


            var repository = _fixture.Create<MovieRepository>();
            var videos = repository.GetMovies();

            videos
                .Select(s => s.imdb_id)
                .Distinct()
                .Should()
                .HaveCount(10)
                .And
                .BeEquivalentTo(new[] 
                {
                    "tt1","tt2","tt3","tt4","tt5","tt6","tt7","tt8","tt9","tt10"
                });
        }

        [Test]
        public void ShouldReturnEmptyEnumerableIfNoVideosInDataStore()
        {
            var repository = _fixture.Create<MovieRepository>();
            var videos = repository.GetMovies();

            videos
                .Select(s => s.imdb_id)
                .Distinct()
                .Should()
                .BeEmpty();
        }
    }
}