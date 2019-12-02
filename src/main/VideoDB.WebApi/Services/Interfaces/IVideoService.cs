using Evo.WebApi.Models;
using Evo.WebApi.Models.Requests;
using Evo.WebApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoDB.WebApi.Models.ViewModels;

namespace Evo.WebApi.Services.Interfaces
{
    public interface IVideoService
    {
        IEnumerable<MovieViewModel> UpsertMovie(MovieRequest video);
        TvEpisodeViewModel UpsertTvEpisode(TvEpisodeRequest tvEpisode);
        IEnumerable<MovieViewModel> GetMovies();
        IEnumerable<TvEpisodeViewModel> GetTvEpisodes();
        IEnumerable<SeriesViewModel> GetTvShows();
    }
}
