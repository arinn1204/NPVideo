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
