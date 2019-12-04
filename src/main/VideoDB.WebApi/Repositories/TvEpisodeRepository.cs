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
using VideoDB.WebApi.Models.Extensions;
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
            var command = tvEpisode.CreateTvEpisodeCommand(sqlConnection);

            return ReadFromDatabase(command);
        }

        public IEnumerable<SeriesDataModel> GetTvShows(string imdb_id = null)
        {
            var seriesCommand =
    @"SELECT video_id, imdb_id, title, plot, release_date, mpaa_rating
FROM video.vw_tv_series
WHERE @imdb_id IS NULL OR imdb_id = @imdb_id";
            using var sqlConnection = new SqlConnection(_configuration.CreateConnectionString());
            var command = new SqlCommand(seriesCommand, sqlConnection);
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@imdb_id", imdb_id));

            return ReadFromDatabase<SeriesDataModel>(command);
        }


        public (IEnumerable<SeriesDataModel> videoDataModels, 
            IEnumerable<TvEpisodeDataModel> tvDataModels)
            GetTvEpisodes(string imdb_id = null)
        {
            var tvEpisodeCommand =
    @"SELECT video_id, imdb_id, title, plot, release_date, mpaa_rating
FROM video.vw_tv_series
WHERE @imdb_id IS NULL OR imdb_id = @imdb_id

SELECT tv_episode_id, series_id, imdb_id, season_number, episode_number,
    episode_name, release_date, plot
FROM video.vw_tv_episodes
WHERE @imdb_id IS NULL OR episode_imdb_id = @imdb_id";
            using var sqlConnection = new SqlConnection(_configuration.CreateConnectionString());
            var command = new SqlCommand(tvEpisodeCommand, sqlConnection);
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@imdb_id", imdb_id));

            return ReadFromDatabase(command);
        }

        private IEnumerable<T> ReadFromDatabase<T>(SqlCommand command)
            where T : class, new()
        {
            var dataModels = Enumerable.Empty<T>();
            try
            {
                command.Connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataModels = dataModels.Append(reader.CreateObject<T>());
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
    }
}
