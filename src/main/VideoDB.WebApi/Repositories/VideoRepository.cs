using Evo.WebApi.Models.DataModel;
using Evo.WebApi.Models.Requests;
using Evo.WebApi.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoDB.WebApi.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly SqlConnection _sqlConnection;

        public VideoRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public IEnumerable<TvEpisodeDataModel> UpsertTvEpisode(TvEpisodeRequest tvEpisode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VideoDataModel> UpsertVideo(VideoRequest video)
        {
            throw new NotImplementedException();
        }
    }
}
