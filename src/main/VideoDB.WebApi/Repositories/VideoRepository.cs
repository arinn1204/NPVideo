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

namespace VideoDB.WebApi.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly IConfiguration _configuration;

        public VideoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<TvEpisodeDataModel> UpsertTvEpisode(TvEpisodeRequest tvEpisode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VideoDataModel> UpsertVideo(VideoRequest video)
        {
            using var sqlConnection = new SqlConnection(_configuration.CreateConnectionString());
            using var genres = CreateDataTable(video.Genres);
            using var stars = CreateDataTable(
                video.Actors
                    .Concat(video.Producers)
                    .Concat(video.Directors)
                    .Concat(video.Writers));
            using var ratings = CreateDataTable(video.Ratings);

            var command = new SqlCommand("[video].[usp_add_movie_or_series]", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            AddParametersToProcedure(video, genres, stars, ratings, command);


            var dataModels = Enumerable.Empty<VideoDataModel>();
            try
            {
                command.Connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataModels = dataModels.Append(reader.CreateObject<VideoDataModel>());
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

        private void AddParametersToProcedure(VideoRequest video, DataTable genres, DataTable stars, DataTable ratings, SqlCommand command)
        {
            command.Parameters.Add(CreateParameter("@imdb_id", video.VideoId));
            command.Parameters.Add(CreateParameter("@title", video.Title));
            command.Parameters.Add(CreateParameter("@mpaa_rating", video.MpaaRating));
            command.Parameters.Add(CreateParameter("@runtime", video.Runtime));
            command.Parameters.Add(CreateParameter("@plot", video.Plot));
            command.Parameters.Add(CreateParameter("@video_type", video.Type.ToString()));
            command.Parameters.Add(CreateParameter("@release_date", video.ReleaseDate));
            command.Parameters.Add(CreateParameter("@resolution", video.Resolution));
            command.Parameters.Add(CreateParameter("@codec", video.Codec));
            command.Parameters.Add(CreateParameter("@extended", video.Extended));
            AddTableParameter("@genres", genres, command);
            AddTableParameter("@persons", stars, command);
            AddTableParameter("@ratings", ratings, command);
        }

        private SqlParameter CreateParameter(string name, string value)
        {
            var param = new SqlParameter(name, value)
            {
                SqlDbType = SqlDbType.VarChar
            };

            return param;
        }

        private SqlParameter CreateParameter(string name, decimal value)
        {
            var param = new SqlParameter(name, value)
            {
                SqlDbType = SqlDbType.Decimal
            };

            return param;
        }

        private SqlParameter CreateParameter(string name, DateTime value)
        {
            var param = new SqlParameter(name, value)
            {
                SqlDbType = SqlDbType.DateTime
            };

            return param;
        }

        private void AddTableParameter(string paramName, DataTable tableToAdd, SqlCommand command)
        {
            var param = command.Parameters.AddWithValue(paramName, tableToAdd);
            param.SqlDbType = SqlDbType.Structured;
        }

        private DataTable CreateDataTable(IEnumerable<GenreRequest> requests)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("name", typeof(string));
            
            foreach (var request in requests)
            {
                dataTable.Rows.Add(request.Name);
            }

            return dataTable;
        }

        private DataTable CreateDataTable(IEnumerable<StarRequest> requests)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("first_name", typeof(string));
            dataTable.Columns.Add("middle_name", typeof(string));
            dataTable.Columns.Add("last_name", typeof(string));
            dataTable.Columns.Add("suffix", typeof(string));
            dataTable.Columns.Add("role_name", typeof(string));

            foreach (var request in requests)
            {
                dataTable.Rows.Add(request.FirstName, request.MiddleName, request.LastName, request.Suffix, request.Role.ToString());
            }

            return dataTable;
        }

        private DataTable CreateDataTable(IEnumerable<RatingRequest> requests)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("source", typeof(string));
            dataTable.Columns.Add("value", typeof(string));

            foreach (var request in requests)
            {
                dataTable.Rows.Add(request.Source, request.RatingValue);
            }

            return dataTable;
        }
    }
}
