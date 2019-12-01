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
using VideoDB.WebApi.Models.Extensions;
using VideoDB.WebApi.Repositories.Helpers;

namespace VideoDB.WebApi.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IConfiguration _configuration;

        public MovieRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<MovieDataModel> UpsertMovie(MovieRequest video)
        {
            using var sqlConnection = new SqlConnection(_configuration.CreateConnectionString());
            var command = video.CreateMovieCommand(sqlConnection);

            return ReadFromDatabase<MovieDataModel>(command);
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
    }
}
