using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using Evo.WebApi;
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
                    Codec = "codec",
                    Title = "title",
                    MpaaRating = "R",
                    Plot = "plot",
                    ReleaseDate = DateTime.MaxValue,
                    Resolution = "resolution",
                    Runtime = 120.33M,
                    VideoType = VideoType.Movie,
                    Stars = new[]
                    {
                        new StarViewModel
                        {
                            FirstName = "Jake",
                            LastName = "Johnson",
                            Role = PersonType.Actor
                        },
                        new StarViewModel
                        {
                            FirstName = "John",
                            LastName = "Johnson",
                            Role = PersonType.Director
                        },
                        new StarViewModel
                        {
                            FirstName = "Jacob",
                            LastName = "Johnson",
                            Role = PersonType.Producer
                        }
                    },
                    Genres = new[]
                    {
                        new GenreViewModel { Name = "Horror" },
                        new GenreViewModel { Name = "Action" },
                        new GenreViewModel { Name = "Adventure" },
                    },
                    Ratings = new[]
                    {
                        new RatingViewModel 
                        { 
                            Source = "Metacritic", 
                            RatingValue = 11.32M 
                        },
                        new RatingViewModel 
                        { 
                            Source = "Rotten Tomato", 
                            RatingValue = 113.32M 
                        },
                    }
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
                Codec = "codec",
                EpisodeName = "title",
                MpaaRating = "R",
                Plot = "plot",
                ReleaseDate = DateTime.MaxValue,
                Resolution = "resolution",
                Runtime = 120.33M,
                EpisodeNumber = 1,
                SeasonNumber = 1,
                Stars = new[]
                    {
                        new StarViewModel
                        {
                            FirstName = "Jake",
                            LastName = "Johnson",
                            Role = PersonType.Actor
                        },
                        new StarViewModel
                        {
                            FirstName = "John",
                            LastName = "Johnson",
                            Role = PersonType.Director
                        },
                        new StarViewModel
                        {
                            FirstName = "Jacob",
                            LastName = "Johnson",
                            Role = PersonType.Producer
                        }
                    },
                Genres = new[]
                    {
                        new GenreViewModel { Name = "Horror" },
                        new GenreViewModel { Name = "Action" },
                        new GenreViewModel { Name = "Adventure" },
                    },
                Ratings = new[]
                    {
                        new RatingViewModel
                        {
                            Source = "Metacritic",
                            RatingValue = 11.32M
                        },
                        new RatingViewModel
                        {
                            Source = "Rotten Tomato",
                            RatingValue = 113.32M
                        },
                    }
            });

            result.Series.Should().BeEquivalentTo(new SeriesViewModel
            {
                SeriesId = 1,
                VideoId = "tt2222",
                Title = "title",
                Plot = "plot",
                ReleaseDate = DateTime.MaxValue,
                Stars = new[]
                   {
                        new StarViewModel
                        {
                            FirstName = "Jake",
                            LastName = "Johnson",
                            Role = PersonType.Actor
                        },
                        new StarViewModel
                        {
                            FirstName = "John",
                            LastName = "Johnson",
                            Role = PersonType.Director
                        },
                        new StarViewModel
                        {
                            FirstName = "Jacob",
                            LastName = "Johnson",
                            Role = PersonType.Producer
                        }
                    },
                Genres = new[]
                   {
                        new GenreViewModel { Name = "Horror" },
                        new GenreViewModel { Name = "Action" },
                        new GenreViewModel { Name = "Adventure" },
                    },
                Ratings = new[]
                   {
                        new RatingViewModel
                        {
                            Source = "Metacritic",
                            RatingValue = 11.32M
                        },
                        new RatingViewModel
                        {
                            Source = "Rotten Tomato",
                            RatingValue = 113.32M
                        },
                    }
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

        private IEnumerable<TvEpisodeDataModel> CreateEpisodeModel(string imdbId, int seriesId = 1, int episodeId = 1)
        {
            var people = CreatePeople();
            var genres = CreateGenres();
            var ratings = CreateRatings();

            foreach (var person in people)
            {
                foreach (var genre in genres)
                {
                    foreach (var rating in ratings)
                    {
                        yield return new TvEpisodeDataModel
                        {
                            series_id = seriesId,
                            tv_episode_id = episodeId,
                            episode_imdb_id = imdbId,
                            codec = "codec",
                            first_name = person.FirstName,
                            genre_name = genre.Name,
                            last_name = person.LastName,
                            middle_name = person.MiddleName,
                            rating = "R",
                            episode_name = "title",
                            person_role = person.Role.ToString(),
                            plot = "plot",
                            rating_source = rating.Source,
                            rating_value = rating.RatingValue,
                            release_date = DateTime.MaxValue,
                            resolution = "resolution",
                            runtime = 120.33M,
                            suffix = person.Suffix,
                            episode_number = 1,
                            season_number = 1
                        };
                    }
                }
            }
        }

        private IEnumerable<SeriesDataModel> CreateSeriesDataModel(string imdbId, int seriesId = 1)
        {
            var people = CreatePeople();
            var genres = CreateGenres();
            var ratings = CreateRatings();

            foreach (var person in people)
            {
                foreach (var genre in genres)
                {
                    foreach (var rating in ratings)
                    {
                        yield return new SeriesDataModel
                        {
                            video_id = seriesId,
                            imdb_id = imdbId,
                            first_name = person.FirstName,
                            genre_name = genre.Name,
                            last_name = person.LastName,
                            middle_name = person.MiddleName,
                            person_role = person.Role.ToString(),
                            plot = "plot",
                            rating_source = rating.Source,
                            rating_value = rating.RatingValue,
                            release_date = DateTime.MaxValue,
                            suffix = person.Suffix,
                            title = "title"
                        };
                    }
                }
            }
        }



        private IEnumerable<MovieDataModel> CreateVideoDataModel(string imdbId, int videoId = 1)
        {
            var people = CreatePeople();
            var genres = CreateGenres();
            var ratings = CreateRatings();

            foreach (var person in people)
            {
                foreach (var genre in genres)
                {
                    foreach (var rating in ratings)
                    {
                        yield return new MovieDataModel
                        {
                            video_id = videoId,
                            imdb_id = imdbId,
                            codec = "codec",
                            first_name = person.FirstName,
                            genre_name = genre.Name,
                            last_name = person.LastName,
                            middle_name = person.MiddleName,
                            movie_rating = "R",
                            movie_title = "title",
                            person_role = person.Role.ToString(),
                            plot = "plot",
                            rating_source = rating.Source,
                            rating_value = rating.RatingValue,
                            release_date = DateTime.MaxValue,
                            resolution = "resolution",
                            runtime = 120.33M,
                            suffix = person.Suffix
                        };
                    }
                }
            }
        }

        private IEnumerable<RatingRequest> CreateRatings()
        {
            return new[]
            {
                new RatingRequest
                {
                    RatingValue = 11.32M,
                    Source = "Metacritic"
                },
                new RatingRequest
                {
                    RatingValue = 113.32M,
                    Source = "Rotten Tomato"
                }
            };
        }

        private IEnumerable<GenreRequest> CreateGenres()
        {
            return new[]
            {
                new GenreRequest { Name = "Horror" },
                new GenreRequest { Name = "Action" },
                new GenreRequest { Name = "Adventure" },
            };
        }

        private IEnumerable<StarRequest> CreatePeople()
        {
            return new[]
            {
                new StarRequest
                {
                    FirstName = "Jake",
                    LastName = "Johnson",
                    Role = PersonType.Actor
                },
                new StarRequest
                {
                    FirstName = "John",
                    LastName = "Johnson",
                    Role = PersonType.Director
                },
                new StarRequest
                {
                    FirstName = "Jacob",
                    LastName = "Johnson",
                    Role = PersonType.Producer
                }
            };
        }
    }
}
