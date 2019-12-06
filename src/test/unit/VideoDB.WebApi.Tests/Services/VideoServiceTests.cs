using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using Evo.WebApi;
using Evo.WebApi.Exceptions;
using Evo.WebApi.Models.DataModel;
using Evo.WebApi.Models.Enums;
using Evo.WebApi.Models.Requests;
using Evo.WebApi.Models.ViewModels;
using Evo.WebApi.Repositories.Interfaces;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using VideoDB.WebApi.Models.ViewModels;
using VideoDB.WebApi.Repositories.Interfaces;
using VideoDB.WebApi.Services;
using VideoDB.WebApi.Tests.Helpers;

namespace VideoDB.WebApi.Tests.Services
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Fixture _fixture;
        private Mock<IMovieRepository> _videoRepo;
        private Mock<ITvEpisodeRepository> _tvRepo;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());

            var mapperConfig = 
                new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(Startup).Assembly));

            var mapper = new Mapper(mapperConfig);
            _fixture.Inject<IMapper>(mapper);

            _videoRepo = _fixture.Freeze<Mock<IMovieRepository>>();
            _tvRepo = _fixture.Freeze<Mock<ITvEpisodeRepository>>();
        }

        [Test]
        public void ShouldMapVideoDatamodelToViewModel()
        {
            _videoRepo.Setup(s => s.UpsertMovie(It.IsAny<MovieRequest>()))
                .Returns(CreateVideoDataModel("tt1234"));

            var service = _fixture.Create<VideoService>();


            var result = service.UpsertMovie(RequestGenerator.GetMovieRequest());

            result.Should()
                .BeEquivalentTo(
                new MovieViewModel
                {
                    VideoId = "tt1234",
                    Title = "title",
                    MpaaRating = "R",
                    Plot = "plot",
                    ReleaseDate = DateTime.MaxValue,
                    Runtime = 120.33M,
                    VideoType = VideoType.Movie
                });
        }

        [Test]
        public void ShouldMapTvEpisodeDataModelToViewModel()
        {
            _tvRepo.Setup(s => s.UpsertTvEpisode(It.IsAny<TvEpisodeRequest>()))
                .Returns((CreateSeriesDataModel("tt2222"), CreateEpisodeModel("tt1234")));

            var service = _fixture.Create<VideoService>();


            var result = service.UpsertTvEpisode(RequestGenerator.GetTvEpisodeRequest());

            result.Episode.Should().BeEquivalentTo(new TvEpisode
            {
                VideoId = "tt1234",
                EpisodeName = "title",
                MpaaRating = "R",
                Plot = "plot",
                ReleaseDate = DateTime.MaxValue,
                Runtime = 120.33M,
                EpisodeNumber = 1,
                SeasonNumber = 1
            });

            result.Series.Should().BeEquivalentTo(new SeriesViewModel
            {
                SeriesId = 1,
                VideoId = "tt2222",
                Title = "title",
                Plot = "plot",
                ReleaseDate = DateTime.MaxValue
            });
        }

        [Test]
        public void ShouldRetrieveAllMoviesFromDatabase()
        {
            _videoRepo.Setup(s => s.GetMovies(It.IsAny<string>()))
                .Returns(CreateVideoDataModel("tt1234").Concat(CreateVideoDataModel("tt12345", 2)));

            var service = _fixture.Create<VideoService>();

            var movies = service.GetMovies();

            movies.Select(s => s.VideoId)
                .Should()
                .HaveCount(2)
                .And
                .BeEquivalentTo(new[] { "tt1234", "tt12345" });
        }
        
        [Test]
        public void ShouldRetrieveAllTvEpisodesFromDatabase()
        {
            _tvRepo.Setup(s => s.GetTvEpisodes(It.IsAny<string>()))
                .Returns(
                (CreateSeriesDataModel("tt2222").Concat(CreateSeriesDataModel("tt2223", 2)),
                CreateEpisodeModel("tt1234").Concat(CreateEpisodeModel("tt12345", 2, 2))));

            var service = _fixture.Create<VideoService>();
            var tvEpisodes = service.GetTvEpisodes();

            tvEpisodes.Select(s => s.Series.VideoId)
                .Should()
                .HaveCount(2)
                .And
                .BeEquivalentTo(new[] { "tt2222", "tt2223" });

            tvEpisodes.SelectMany(s => s.Episode)
                .Select(s => s.VideoId)
                .Should()
                .HaveCount(2)
                .And
                .BeEquivalentTo(new[] { "tt1234", "tt12345" });

        }


        [Test]
        public void ShouldRetrieveAllTvSeriesFromDatabase()
        {
            _tvRepo.Setup(s => s.GetTvShows(It.IsAny<string>()))
                .Returns(
                CreateSeriesDataModel("tt2222").Concat(CreateSeriesDataModel("tt2223", 2)));

            var service = _fixture.Create<VideoService>();
            var tvEpisodes = service.GetTvShows();

            tvEpisodes.Select(s => s.VideoId)
                .Should()
                .HaveCount(2)
                .And
                .BeEquivalentTo(new[] { "tt2222", "tt2223" });
        }

        [Test]
        public void ShouldRetrieveSpecificMovieFromDatabase()
        {
            var calledId = string.Empty;
            _videoRepo.Setup(s => s.GetMovies(It.IsAny<string>()))
                .Callback((string id) => calledId = id)
                .Returns(CreateVideoDataModel("tt1234").Concat(CreateVideoDataModel("tt12345", 2)));

            var service = _fixture.Create<VideoService>();

            var movies = service.GetMovies("tt1234");
            calledId.Should()
                .Be("tt1234");
        }

        [Test]
        public void ShouldRetrieveSpecificTvShowFromDatabase()
        {
            var calledId = string.Empty;
            _tvRepo.Setup(s => s.GetTvShows(It.IsAny<string>()))
                .Callback((string id) => calledId = id)
                .Returns(
                CreateSeriesDataModel("tt2222").Concat(CreateSeriesDataModel("tt2223", 2)));

            var service = _fixture.Create<VideoService>();
            var tvEpisodes = service.GetTvShows("tt2222");

            calledId.Should()
                .Be("tt2222");
        } 

        [Test]
        public void ShouldRetrieveSpecificTvEpisodeFromDatabase()
        {
            var calledId = string.Empty;
            _tvRepo.Setup(s => s.GetTvEpisodes(It.IsAny<string>()))
                .Callback((string id) => calledId = id)
                .Returns(
                (CreateSeriesDataModel("tt2222").Concat(CreateSeriesDataModel("tt2223", 2)),
                CreateEpisodeModel("tt1234").Concat(CreateEpisodeModel("tt12345", 2, 2))));

            var service = _fixture.Create<VideoService>();
            var tvEpisodes = service.GetTvEpisodes("tt1234");

            calledId.Should()
                .Be("tt1234");

        }

        [TestCase("movie", "NotExist")]
        [TestCase("show", "NotExist")]
        [TestCase("tv episode", "NotExist")]
        public void ShouldThrowNotFoundExceptionIfLookingForSpecificVideoFromDatabase(string type, string id)
        {
            _tvRepo.Setup(
                s => s.GetTvEpisodes(It.IsAny<string>()))
                .Returns(
                    (Enumerable.Empty<SeriesDataModel>(),
                    Enumerable.Empty<TvEpisodeDataModel>()));

            _tvRepo.Setup(
                s => s.GetTvShows(It.IsAny<string>()))
                .Returns(Enumerable.Empty<SeriesDataModel>());

            _videoRepo.Setup(s => s.GetMovies(It.IsAny<string>()))
                .Returns(Enumerable.Empty<MovieDataModel>());

            var service = _fixture.Create<VideoService>();

            var exception = default(Action);
            switch(type)
            {
                case "movie": exception = () => service.GetMovies(id); break;
                case "show": exception = () => service.GetTvShows(id); break;
                case "tv episode": exception = () => service.GetTvEpisodes(id); break;
            }

            exception.Should()
                .Throw<EvoNotFoundException>()
                .WithMessage($"'{id}' does not exist.");
        }

        [TestCase("movie")]
        [TestCase("show")]
        [TestCase("tv episode")]
        public void ShouldNotThrowNotFoundExceptionIfGettingAllVideosButThereAreNone(string type)
        {
            _tvRepo.Setup(
                s => s.GetTvEpisodes(It.IsAny<string>()))
                .Returns(
                    (Enumerable.Empty<SeriesDataModel>(),
                    Enumerable.Empty<TvEpisodeDataModel>()));

            _tvRepo.Setup(
                s => s.GetTvShows(It.IsAny<string>()))
                .Returns(Enumerable.Empty<SeriesDataModel>());

            _videoRepo.Setup(s => s.GetMovies(It.IsAny<string>()))
                .Returns(Enumerable.Empty<MovieDataModel>());

            var service = _fixture.Create<VideoService>();

            var exception = default(Action);
            var result = Enumerable.Empty<object>();
            switch (type)
            {
                case "movie": exception = () => result = service.GetMovies(); break;
                case "show": exception = () => result = service.GetTvShows(); break;
                case "tv episode": exception = () => result = service.GetTvEpisodes(); break;
            }

            exception.Should().NotThrow();
            result.Should().BeEmpty();
        }


        private IEnumerable<TvEpisodeDataModel> CreateEpisodeModel(string imdbId, int seriesId = 1, int episodeId = 1)
        {
            yield return new TvEpisodeDataModel
            {
                series_id = seriesId,
                tv_episode_id = episodeId,
                imdb_id = imdbId,
                rating = "R",
                episode_name = "title",
                plot = "plot",
                release_date = DateTime.MaxValue,
                runtime = 120.33m,
                episode_number = 1,
                season_number = 1
            };
        }

        private IEnumerable<SeriesDataModel> CreateSeriesDataModel(string imdbId, int seriesId = 1)
        {
            yield return new SeriesDataModel
            {
                video_id = seriesId,
                imdb_id = imdbId,
                plot = "plot",
                release_date = DateTime.MaxValue,
                title = "title"
            };
        }



        private IEnumerable<MovieDataModel> CreateVideoDataModel(string imdbId, int videoId = 1)
        {
            yield return new MovieDataModel
            {
                video_id = videoId,
                imdb_id = imdbId,
                movie_rating = "R",
                movie_title = "title",
                plot = "plot",
                release_date = DateTime.MaxValue,
                runtime = 120.33M
            };
        }
    }
}
