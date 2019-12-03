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
                VideoId = "tt1234"
            };

            _service.Setup(s => s.UpsertMovie(request))
                .Returns(new MovieViewModel
                {
                    VideoId = "tt1234"
                }.Yield());

            var result = _controller.UpsertVideo(request) as CreatedResult;

            result.Should().NotBe(null);
            result.Location.Should().Be("/videos/movies/tt1234");
            (result.Value as IEnumerable<MovieViewModel>).First().VideoId.Should().Be("tt1234");
        }

        [Test]
        public void ShouldReturnNoContentWhenSuccessfulUpdate()
        {
            var request = new MovieRequest()
            {
                VideoId = "tt1234"
            };

            _service.Setup(s => s.UpsertMovie(request))
                .Returns(new MovieViewModel
                {
                    VideoId = "tt1234",
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
                    VideoId = "tt1234"
                },
                new MovieViewModel
                {
                    VideoId = "tt1235"
                },
                new MovieViewModel
                {
                    VideoId = "tt1236"
                }
            };

            _service.Setup(s => s.GetMovies(It.IsAny<string>())).Returns(movies);

            var result = _controller.GetAllMovies() as OkObjectResult;
            var moviesResult = result.Value as IEnumerable<MovieViewModel>;

            moviesResult.Select(s => s.VideoId)
                .Should()
                .BeEquivalentTo(new[] { "tt1234", "tt1235", "tt1236" });
        }


    }
}
