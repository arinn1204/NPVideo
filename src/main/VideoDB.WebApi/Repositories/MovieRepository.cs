﻿using Evo.WebApi.Exceptions;
using Evo.WebApi.Models.DataModel;
using Evo.WebApi.Models.Requests;
using Evo.WebApi.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
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

        public IEnumerable<MovieDataModel> GetMovies(string imdbId = null)
        {
            var movieCommand = @"
SELECT video_id, imdb_id, movie_title, movie_rating, runtime, plot, release_date
FROM video.vw_movies
WHERE @imdb_id IS NULL OR imdb_id = @imdb_id";

            using var sqlConnection = new SqlConnection(_configuration.CreateConnectionString());
            var command = new SqlCommand(movieCommand, sqlConnection);
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@imdb_id", imdbId));

            return ReadFromDatabase<MovieDataModel>(command);
        }

        private IEnumerable<TDataModel> ReadFromDatabase<TDataModel>(SqlCommand command)
            where TDataModel : class, new()
        {
            var dataModels = Enumerable.Empty<TDataModel>();
            try
            {
                command.Connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataModels = dataModels.Append(reader.CreateObject<TDataModel>());
                }
            }
            catch (SqlException e)
            {
                var regex = new Regex(@"(?<=@)(\w+) is a required parameter(?: for video_type = movie)?\.$");
                var matchGroup = regex.Match(e.Message);
                if (matchGroup.Success)
                {
                    var missingParameter = matchGroup.Groups.Count > 1
                        ? matchGroup.Groups[1].Value
                        : matchGroup.Groups[0].Value;

                    var property = missingParameter switch
                    {
                        "codec" => "Codec",
                        "resolution" => "Resolution",
                        "imdb_id" => "VideoId",
                        "mpaa_rating" => "MpaaRating",
                        _ => missingParameter
                    };

                    throw new EvoBadRequestException($"{property} can not be null.");
                }

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
