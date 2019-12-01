using Evo.WebApi.Models.Requests;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using VideoDB.WebApi.Extensions;
using VideoDB.WebApi.Models.Extensions;

namespace VideoDB.WebApi.Tests.Integration.Features.Steps.Support
{
    public static class Database
    {
        public static void AddRequestItem(MovieRequest request, IConfiguration configuration)
        {
            var connection = configuration.CreateConnectionString();
            using var sqlConnection = new SqlConnection(connection);

            var command = request.CreateMovieCommand(sqlConnection);

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public static void AddRequestItem(TvEpisodeRequest request, IConfiguration configuration)
        {
            var connection = configuration.CreateConnectionString();
            using var sqlConnection = new SqlConnection(connection);
            var command = request.CreateTvEpisodeCommand(sqlConnection);

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
    }
}
