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
            using var command = new SqlCommand($@"INSERT INTO [video].[videos] (imdb_id,title,mpaa_rating,plot,video_type,release_date,runtime)
VALUES ('{request.VideoId}', '{request.Title}', '{request.MpaaRating}', '{request.Plot}', '{request.Type}', '{DateTime.Now}', '{request.Runtime}');", sqlConnection);

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public static void AddRequestItem(TvEpisodeRequest request, IConfiguration configuration)
        {
            var videoSqlCommand = $@"SELECT video_id
FROM [video].[videos]
WHERE imdb_id = '{request.VideoId}'";
            var tvSqlCommand = $@"";

            var connection = configuration.CreateConnectionString();
            using var sqlConnection = new SqlConnection(connection);
            using var videoCommand = new SqlCommand(videoSqlCommand, sqlConnection);
            using var tvCommand = new SqlCommand(tvSqlCommand, sqlConnection);

            videoCommand.Connection.Open();
            var reader = videoCommand.ExecuteReader();
            reader.Read();

            var video_id = reader.GetInt32(0);
            videoCommand.Connection.Close();

            tvCommand.Connection.Open();
            tvCommand.ExecuteNonQuery();
            tvCommand.Connection.Close();
        }
    }
}
