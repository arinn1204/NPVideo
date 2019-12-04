using AutoMapper;
using Evo.WebApi.Exceptions;
using Evo.WebApi.Models.DataModel;
using Evo.WebApi.Models.Enums;
using Evo.WebApi.Models.Requests;
using Evo.WebApi.Models.ViewModels;
using Evo.WebApi.Repositories.Interfaces;
using Evo.WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoDB.WebApi.Models.ViewModels;
using VideoDB.WebApi.Repositories.Interfaces;

namespace VideoDB.WebApi.Services
{
    public class VideoService : IVideoService
    {
        private readonly IMovieRepository _videoRepository;
        private readonly ITvEpisodeRepository _tvEpisodeRepository;
        private readonly IMapper _mapper;

        public VideoService(
            IMovieRepository videoRepository,
            ITvEpisodeRepository tvEpisodeRepository,
            IMapper mapper)
        {
            _videoRepository = videoRepository;
            _tvEpisodeRepository = tvEpisodeRepository;
            _mapper = mapper;
        }

        public TvEpisodeViewModel UpsertTvEpisode(TvEpisodeRequest tvEpisode)
        {
            var (tvShow, tvEpisodeResponse) = _tvEpisodeRepository.UpsertTvEpisode(tvEpisode);

            return new TvEpisodeViewModel
            {
                Episode = tvEpisodeResponse.GroupBy(
                    key => key.tv_episode_id,
                    (episodeId, tvEpisodes) => _mapper.Map<TvEpisode>(
                        tvEpisodes.Where(w => w.tv_episode_id == episodeId))),
                Series = _mapper.Map<SeriesViewModel>(tvShow)
            };
        }

        public IEnumerable<SeriesViewModel> GetTvShows(string imdbId = null)
        {
            var tvShows = _tvEpisodeRepository.GetTvShows(imdbId);

            return tvShows.Any()
                ? tvShows.GroupBy(
                key => key.video_id,
                (_, dataModels) =>
                    _mapper.Map<SeriesViewModel>(dataModels))
                : throw new EvoNotFoundException($"'{imdbId}' does not exist.");
        }

        public IEnumerable<TvEpisodeViewModel> GetTvEpisodes(string imdbId = null)
        {
            var (shows, episodes) = _tvEpisodeRepository.GetTvEpisodes(imdbId);

            if (!shows.Any() || !episodes.Any())
            {
                throw new EvoNotFoundException($"'{imdbId}' does not exist.");
            }

            return shows.GroupJoin(
                episodes,
                outerKey => outerKey.video_id,
                innerKey => innerKey.series_id,
                (series, seriesEpisodes) =>
                    new TvEpisodeViewModel
                    {
                        Series = _mapper.Map<SeriesViewModel>(series),
                        Episode = seriesEpisodes.GroupBy(
                            key => key.tv_episode_id,
                            (episodeId, episodes) => 
                                _mapper.Map<TvEpisode>(
                                    episodes.Where(w => w.tv_episode_id == episodeId)))
                    });
        }

        public IEnumerable<MovieViewModel> UpsertMovie(MovieRequest video)
        {
            return MapToViewModel(_videoRepository.UpsertMovie(video));
        }

        public IEnumerable<MovieViewModel> GetMovies(string imdbId = null)
        {
            var movieDataModel = _videoRepository.GetMovies(imdbId);

            return movieDataModel.Any() 
                ? MapToViewModel(movieDataModel)
                : throw new EvoNotFoundException($"'{imdbId}' does not exist.");
        }

        private IEnumerable<MovieViewModel> MapToViewModel(IEnumerable<MovieDataModel> dataModels)
        {
            return dataModels.GroupBy(
                key => key.video_id,
                (key, dataModels) =>
                    _mapper.Map<MovieViewModel>(
                        dataModels.Where(w => w.video_id == key)));
        }
    }
}
