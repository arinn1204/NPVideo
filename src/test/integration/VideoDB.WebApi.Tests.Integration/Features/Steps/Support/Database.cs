using Evo.WebApi.Models.Requests;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using VideoDB.WebApi.Extensions;

namespace VideoDB.WebApi.Tests.Integration.Features.Steps.Support
{
    public static class Database
    {
        public static void AddRequestItem(VideoRequest request, IConfiguration configuration)
        {
            var connection = configuration.CreateConnectionString();
            using var sqlConnection = new SqlConnection(connection);
            using var command = new SqlCommand($@"INSERT INTO [video].[videos] (imdb_id,title,mpaa_rating,plot,video_type,release_date)
VALUES ('{request.VideoId}', '{request.Title}', '{request.MpaaRating}', '{request.Plot}', '{request.Type}', '{DateTime.Now}');", sqlConnection);

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
    }
}
