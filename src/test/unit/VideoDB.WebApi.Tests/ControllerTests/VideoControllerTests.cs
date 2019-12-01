using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evo.WebApi.Controllers;
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
        public void ShouldReturnInternalServerErrorWhenAnyExceptionThrown()
        {
            _service.Setup(s => s.UpsertMovie(It.IsAny<MovieRequest>()))
                .Throws(new Exception());

            var objectResult = _controller.UpsertVideo(new MovieRequest()) as ObjectResult;
            var videoResult = objectResult.Value as ErrorResponse;
            Assert.That(videoResult, Is.Not.Null);
            Assert.That(objectResult.StatusCode, Is.EqualTo(StatusCodes.Status500InternalServerError));
            Assert.That(videoResult.Error, Is.Not.Null);
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

    }
}
