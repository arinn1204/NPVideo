using Evo.WebApi.Models.Requests;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VideoDB.WebApi.Repositories.Helpers;

namespace VideoDB.WebApi.Models.Extensions
{
    public static class RequestExtensions
    {
        public static SqlCommand CreateTvEpisodeCommand(
          this TvEpisodeRequest tvEpisode,
          SqlConnection sqlConnection)
        {
            var command = new SqlCommand("[video].[usp_add_tv_episode]", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            using var genres = CreateSqlParameter.CreateDataTable(tvEpisode.Genres);
            using var stars = CreateSqlParameter.CreateDataTable(
                tvEpisode.Actors
                    .Concat(tvEpisode.Producers)
                    .Concat(tvEpisode.Directors)
                    .Concat(tvEpisode.Writers));
            using var ratings = CreateSqlParameter.CreateDataTable(tvEpisode.Ratings);
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

            return command;
        }

        public static SqlCommand CreateMovieCommand(
           this MovieRequest video,
           SqlConnection sqlConnection)
        {
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
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@imdb_id", video.VideoId));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@title", video.Title));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@mpaa_rating", video.MpaaRating));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@runtime",
                video.Runtime.HasValue
                ? video.Runtime.Value.ToString()
                : "null"));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@plot", video.Plot));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@video_type", video.Type.ToString()));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@release_date", video.ReleaseDate));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@resolution", video.Resolution));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@codec", video.Codec));
            command.Parameters.Add(CreateSqlParameter.CreateParameter("@extended", video.Extended));
            CreateSqlParameter.AddTableParameter("@genres", genres, command);
            CreateSqlParameter.AddTableParameter("@persons", stars, command);
            CreateSqlParameter.AddTableParameter("@ratings", ratings, command);

            return command;
        }
    }
}
