using Evo.WebApi.Exceptions;
using Evo.WebApi.Models.DataModel;
using Evo.WebApi.Models.Requests;
using Evo.WebApi.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VideoDB.WebApi.Extensions;
using VideoDB.WebApi.Repositories.Helpers;

namespace VideoDB.WebApi.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly IConfiguration _configuration;

        public VideoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<VideoDataModel> UpsertVideo(VideoRequest video)
        {
            using var sqlConnection = new SqlConnection(_configuration.CreateConnectionString());
            using var genres = CreateSqlParameter.CreateDataTable(video.Genres);
            using var stars = CreateSqlParameter.CreateDataTable(
                video.Actors
                    .Concat(video.Producers)
                    .Concat(video.Directors)
                    .Concat(video.Writers));
            using var ratings = CreateSqlParameter.CreateDataTable(video.Ratings);

            var command = new SqlCommand("[video].[usp_add_movie_or_series]", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            AddParametersToProcedure(video, genres, stars, ratings, command);

            return ReadFromDatabase<VideoDataModel>(command);
        }

        private IEnumerable<TDataModel> ReadFromDatabase<TDataModel>(SqlCommand command, int resultSet = 1)
            where TDataModel : class, new()
        {
            var dataModels = Enumerable.Empty<TDataModel>();
            try
            {
                command.Connection.Open();
                var reader = command.ExecuteReader();

                for (int i = 1; i < resultSet; i++)
                {
                    reader.NextResult();
                }

                while (reader.Read())
                {
                    dataModels = dataModels.Append(reader.CreateObject<TDataModel>());
                }
            }
            catch (SqlException e)
            {
                throw new EvoException(e.Message);
            }
            finally
            {
                command.Connection.Close();
            }


            return dataModels;
        }

        private void AddParametersToProcedure(
            VideoRequest video,
            DataTable genres,
            DataTable stars,
            DataTable ratings,
            SqlCommand command)
        {
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@imdb_id", video.VideoId));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@title", video.Title));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@mpaa_rating", video.MpaaRating));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@runtime", video.Runtime));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@plot", video.Plot));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@video_type", video.Type.ToString()));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@release_date", video.ReleaseDate));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@resolution", video.Resolution));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@codec", video.Codec));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@extended", video.Extended));
            CreateSqlParameter.AddTableParameter("@genres", genres, command);
            CreateSqlParameter.AddTableParameter("@persons", stars, command);
            CreateSqlParameter.AddTableParameter("@ratings", ratings, command);
        }
    }
}
