using System;
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

namespace Evo.WebApi.Tests.Controllers
{
    [TestFixture]
    public class VideosControllerTests
    {
        [SetUp]
        public void Setup()
        {
            _service = new Mock<IVideoService>();

            _controller = new VideosController(_service.Object);
        }

        private Mock<IVideoService> _service;
        private VideosController _controller;

        [Test]
        public async Task ShouldReturnCreatedWhenSuccessfulCreation()
        {
            var request = new VideoRequest()
            {
                VideoId = "tt1234"
            };

            _service.Setup(s => s.UpsertVideo(request))
                .Returns(new VideoViewModel
                {
                    VideoId = "tt1234"
                });

            var result = await _controller.AddVideo(request) as CreatedResult;

            result.Should().NotBe(null);
            result.Location.Should().Be("/videos/tt1234");
            (result.Value as VideoViewModel).VideoId.Should().Be("tt1234");
        }

        [Test]
        public async Task ShouldReturnInternalServerErrorWhenAnyExceptionThrown()
        {
            _service.Setup(s => s.UpsertVideo(It.IsAny<VideoRequest>()))
                .Throws(new Exception());

            var objectResult = await _controller.AddVideo(new VideoRequest()) as ObjectResult;
            var videoResult = objectResult.Value as ErrorResponse;
            Assert.That(videoResult, Is.Not.Null);
            Assert.That(objectResult.StatusCode, Is.EqualTo(StatusCodes.Status500InternalServerError));
            Assert.That(videoResult.Error, Is.Not.Null);
        }

    }
}
