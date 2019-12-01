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
                Episode = _mapper.Map<TvEpisode>(tvDataModels),
                Series = _mapper.Map<SeriesViewModel>(videoDataModels)
            };
        }

        public IEnumerable<MovieViewModel> UpsertMovie(MovieRequest video)
        {
            var videoViewModels = _videoRepository.UpsertMovie(video)
                .GroupBy(
                    key => key.video_id,
                    (key, dataModels) 
                        =>
                    {
                        var viewModel = _mapper.Map<MovieViewModel>(
                            dataModels.Where(w => w.video_id == key));
                        viewModel.VideoType = VideoType.Movie;

                        return viewModel;
                    });

            return videoViewModels;
        }
    }
}
