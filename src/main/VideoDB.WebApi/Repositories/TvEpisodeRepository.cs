using Evo.WebApi.Exceptions;
using Evo.WebApi.Models.DataModel;
using Evo.WebApi.Models.Requests;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VideoDB.WebApi.Extensions;
using VideoDB.WebApi.Repositories.Helpers;
using VideoDB.WebApi.Repositories.Interfaces;

namespace VideoDB.WebApi.Repositories
{
    public class TvEpisodeRepository : ITvEpisodeRepository
    {
        private readonly IConfiguration _configuration;

        public TvEpisodeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public (IEnumerable<SeriesDataModel> videoDataModels,
               IEnumerable<TvEpisodeDataModel> tvDataModels)
           UpsertTvEpisode(TvEpisodeRequest tvEpisode)
        {
            using var sqlConnection = new SqlConnection(_configuration.CreateConnectionString());
            using var genres = CreateSqlParameter.CreateDataTable(tvEpisode.Genres);
            using var stars = CreateSqlParameter.CreateDataTable(
                tvEpisode.Actors
                    .Concat(tvEpisode.Producers)
                    .Concat(tvEpisode.Directors)
                    .Concat(tvEpisode.Writers));
            using var ratings = CreateSqlParameter.CreateDataTable(tvEpisode.Ratings);

            var command = new SqlCommand("[video].[usp_add_tv_episode]", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            AddEpisodeParameters(tvEpisode, genres, stars, ratings, command);

            return ReadFromDatabase(command);

        }

        private (IEnumerable<SeriesDataModel> videoDataModels,
               IEnumerable<TvEpisodeDataModel> tvDataModels) ReadFromDatabase(SqlCommand command)
        {
            var videoModels = Enumerable.Empty<SeriesDataModel>();
            var episodeModels = Enumerable.Empty<TvEpisodeDataModel>();
            try
            {
                command.Connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    videoModels = videoModels.Append(reader.CreateObject<SeriesDataModel>());
                }

                reader.NextResult();

                while(reader.Read())
                {
                    episodeModels = episodeModels.Append(reader.CreateObject<TvEpisodeDataModel>());
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


            return (videoModels, episodeModels);
        }
        private void AddEpisodeParameters(
          TvEpisodeRequest tvEpisode,
          DataTable genres,
          DataTable stars,
          DataTable ratings,
          SqlCommand command)
        {
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@series_imdb_id", tvEpisode.VideoId));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@series_title", tvEpisode.Title));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@mpaa_rating", tvEpisode.MpaaRating));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@series_plot", tvEpisode.Plot));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@series_release_date", tvEpisode.ReleaseDate));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@episode_imdb_id", tvEpisode.TvEpisodeId));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@runtime", 
                tvEpisode.Runtime.HasValue 
                ? tvEpisode.Runtime.Value.ToString() 
                : "null"));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@episode_release_date", tvEpisode.EpisodeReleaseDate));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@season_number", tvEpisode.SeasonNumber));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@episode_number", tvEpisode.EpisodeNumber));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@episode_name", tvEpisode.EpisodeName));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@plot", tvEpisode.EpisodePlot));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@resolution", tvEpisode.Resolution));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@codec", tvEpisode.Codec));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@extended", tvEpisode.Extended));
            CreateSqlParameter.AddTableParameter("@genres", genres, command);
            CreateSqlParameter.AddTableParameter("@persons", stars, command);
            CreateSqlParameter.AddTableParameter("@ratings", ratings, command);
        }

    }
}
