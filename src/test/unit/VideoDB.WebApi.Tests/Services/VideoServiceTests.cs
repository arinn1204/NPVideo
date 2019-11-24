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
using System.Text;
using VideoDB.WebApi.Repositories.Interfaces;
using VideoDB.WebApi.Services;
using VideoDB.WebApi.Tests.Helpers;

namespace VideoDB.WebApi.Tests.Services
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Fixture _fixture;
        private Mock<IVideoRepository> _videoRepo;
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

            _videoRepo = _fixture.Freeze<Mock<IVideoRepository>>();
            _tvRepo = _fixture.Freeze<Mock<ITvEpisodeRepository>>();
        }

        [Test]
        public void ShouldMapDatamodelToViewModel()
        {
            _videoRepo.Setup(s => s.UpsertVideo(It.IsAny<VideoRequest>()))
                .Returns(CreateVideoDataModel("tt1234"));

            var service = _fixture.Create<VideoService>();


            var result = service.UpsertVideo(RequestGenerator.GetVideoRequest());

            result.Should()
                .BeEquivalentTo(
                new VideoViewModel
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
        

        private IEnumerable<VideoDataModel> CreateVideoDataModel(string imdbId)
        {
            var people = new[]
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

            var genres = new[]
            {
                new GenreRequest { Name = "Horror" },
                new GenreRequest { Name = "Action" },
                new GenreRequest { Name = "Adventure" },
            };

            var ratings = new[]
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

            foreach (var person in people)
            {
                foreach (var genre in genres)
                {
                    foreach (var rating in ratings)
                    {
                        yield return new VideoDataModel
                        {
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

    }
}
