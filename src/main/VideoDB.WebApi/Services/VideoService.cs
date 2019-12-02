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
            var (videoDataModels, tvDataModels) = _tvEpisodeRepository.UpsertTvEpisode(tvEpisode);

            return new TvEpisodeViewModel
            {
                Episode = tvDataModels.GroupBy(
                    key => key.tv_episode_id,
                    (key, dataModels) => _mapper.Map<TvEpisode>(
                        dataModels.Where(w => w.tv_episode_id == key))),
                Series = _mapper.Map<SeriesViewModel>(videoDataModels)
            };
        }

        public IEnumerable<SeriesViewModel> GetTvShows(string imdbId = null)
        {
            var seriesDataModel = _tvEpisodeRepository.GetTvShows(imdbId);

            return seriesDataModel.Any()
                ? seriesDataModel.GroupBy(
                key => key.video_id,
                (key, dataModels) =>
                    _mapper.Map<SeriesViewModel>(dataModels))
                : throw new EvoNotFoundException($"'{imdbId}' does not exist.");
        }

        public IEnumerable<TvEpisodeViewModel> GetTvEpisodes(string imdbId = null)
        {
            var (videoDataModels, tvDataModels) = _tvEpisodeRepository.GetTvEpisodes(imdbId);

            if (!videoDataModels.Any() || !tvDataModels.Any())
            {
                throw new EvoNotFoundException($"'{imdbId}' does not exist.");
            }

            var series = videoDataModels.GroupBy(
                key => key.video_id,
                (key, dataModels) => 
                    _mapper.Map<SeriesViewModel>(
                        dataModels.Where(w => w.video_id == key)));

            return series.GroupJoin(
                tvDataModels,
                outerKey => outerKey.SeriesId,
                innerKey => innerKey.series_id,
                (series, episodes) =>
                    new TvEpisodeViewModel
                    {
                        Series = _mapper.Map<SeriesViewModel>(series),
                        Episode = episodes.GroupBy(
                            key => key.tv_episode_id,
                            (key, dataModels) => 
                                _mapper.Map<TvEpisode>(
                                    dataModels.Where(w => w.tv_episode_id == key)))
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
                {
                    var viewModel = _mapper.Map<MovieViewModel>(
                            dataModels.Where(w => w.video_id == key));
                    viewModel.VideoType = VideoType.Movie;

                    return viewModel;
                });
        }
    }
}
