using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evo.WebApi.Controllers;
using Evo.WebApi.Exceptions;
using Evo.WebApi.Models.Requests;
using Evo.WebApi.Models.ViewModels;
using Evo.WebApi.Services.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using VideoDB.WebApi.Tests.Extensions;

namespace Evo.WebApi.Tests.Controllers
{
    [TestFixture]
    public class VideosControllerTests
    {
        [SetUp]
        public void Setup()
        {
            _service = new Mock<IVideoService>();

            _controller = new MoviesController(_service.Object);
        }

        private Mock<IVideoService> _service;
        private MoviesController _controller;

        [Test]
        public void ShouldReturnCreatedWhenSuccessfulCreation()
        {
            var request = new MovieRequest()
            {
                VideoId = "tt12341236"
            };

            _service.Setup(s => s.UpsertMovie(request))
                .Returns(new MovieViewModel
                {
                    VideoId = "tt12341236"
                }.Yield());

            var result = _controller.UpsertVideo(request) as CreatedResult;

            result.Should().NotBe(null);
            result.Location.Should().Be("/videos/movies/tt12341236");
            (result.Value as IEnumerable<MovieViewModel>).First().VideoId.Should().Be("tt12341236");
        }

        [Test]
        public void ShouldReturnNoContentWhenSuccessfulUpdate()
        {
            var request = new MovieRequest()
            {
                VideoId = "tt12341234"
            };

            _service.Setup(s => s.UpsertMovie(request))
                .Returns(new MovieViewModel
                {
                    VideoId = "tt12341234",
                    IsUpdated = true
                }.Yield());

            var result = _controller.UpsertVideo(request) as NoContentResult;
            result.Should().NotBeNull();
        }

        [Test]
        public void ShouldReturnAllMovies()
        {
            var movies = new[]
            {
                new MovieViewModel
                {
                    VideoId = "tt12341234"
                },
                new MovieViewModel
                {
                    VideoId = "tt12341235"
                },
                new MovieViewModel
                {
                    VideoId = "tt12341236"
                }
            };

            _service.Setup(s => s.GetMovies(It.IsAny<string>())).Returns(movies);

            var result = _controller.GetAllMovies() as OkObjectResult;
            var moviesResult = result.Value as IEnumerable<MovieViewModel>;

            moviesResult.Select(s => s.VideoId)
                .Should()
                .BeEquivalentTo(new[] { "tt12341234", "tt12341235", "tt12341236" });
        }


        [TestCase("t12341234")]
        [TestCase("tt123412")]
        [TestCase("tt1234134212")]
        public void ShouldThrowBadRequestExceptionIfIdDoesntMeetStandard(string id)
        {
            Action exception = () => _controller.GetAllMovies(id);

            exception.Should()
                .Throw<EvoBadRequestException>()
                .WithMessage(id + " is an invalid format. The required format must match: 'tt\\d{7,9}'");
        }

    }
}
