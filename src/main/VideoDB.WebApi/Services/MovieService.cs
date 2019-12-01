using AutoMapper;
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
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _videoRepository;
        private readonly ITvEpisodeRepository _tvEpisodeRepository;
        private readonly IMapper _mapper;

        public MovieService(
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
                Episode = _mapper.Map<TvEpisode>(tvDataModels),
                Series = _mapper.Map<SeriesViewModel>(videoDataModels)
            };
        }

        public MovieViewModel UpsertMovie(MovieRequest video)
        {
            var dataModel = _videoRepository.UpsertMovie(video);
            
            var videoViewModel = _mapper.Map<MovieViewModel>(dataModel);
            videoViewModel.VideoType = VideoType.Movie;

            return videoViewModel;
        }
    }
}
