using Evo.WebApi.Models.DataModel;
using Evo.WebApi.Models.Requests;
using System.Collections.Generic;

namespace VideoDB.WebApi.Repositories.Interfaces
{
    public interface ITvEpisodeRepository
    {

        (IEnumerable<SeriesDataModel> tvShow, IEnumerable<TvEpisodeDataModel> tvEpisodes)
            UpsertTvEpisode(TvEpisodeRequest tvEpisode);

        (IEnumerable<SeriesDataModel> tvShows, IEnumerable<TvEpisodeDataModel> tvEpisodes)
            GetTvEpisodes(string imdb_id = null);

        IEnumerable<SeriesDataModel> GetTvShows(string imdb_id = null);
    }
}
