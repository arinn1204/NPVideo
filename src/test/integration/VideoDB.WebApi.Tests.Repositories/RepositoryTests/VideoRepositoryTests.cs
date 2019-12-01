using AutoBogus;
using AutoFixture;
using AutoFixture.AutoMoq;
using Bogus;
using Evo.WebApi.Exceptions;
using Evo.WebApi.Models.Enums;
using Evo.WebApi.Models.Requests;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
            var request = RequestGenerator.GetMovieRequest("134132");
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
    }
}