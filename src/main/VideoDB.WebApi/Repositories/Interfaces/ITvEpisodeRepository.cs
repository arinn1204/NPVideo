using Evo.WebApi.Models.DataModel;
using Evo.WebApi.Models.Requests;
using System.Collections.Generic;

namespace VideoDB.WebApi.Repositories.Interfaces
{
    public interface ITvEpisodeRepository
    {

        (IEnumerable<SeriesDataModel> videoDataModels, IEnumerable<TvEpisodeDataModel> tvDataModels)
            UpsertTvEpisode(TvEpisodeRequest tvEpisode);

        (IEnumerable<SeriesDataModel> videoDataModels, IEnumerable<TvEpisodeDataModel> tvDataModels)
            GetTvEpisodes(string imdb_id = null);

        IEnumerable<SeriesDataModel> GetTvShows(string imdb_id = null);
    }
}
