using Evo.WebApi.Controllers;
using Evo.WebApi.Models.Requests;
using Evo.WebApi.Models.ViewModels;
using Evo.WebApi.Services.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using VideoDB.WebApi.Models.ViewModels;

namespace VideoDB.WebApi.Tests.ControllerTests
{
    [TestFixture]
    class TvEpisodeControllerTests
    {
        private Mock<IVideoService> _service;
        private TvEpisodesController _controller;

        [SetUp]
        public void Setup()
        {
            _service = new Mock<IVideoService>();

            _controller = new TvEpisodesController(_service.Object);
        }


        [Test]
        public void ShouldReturnCreatedWhenSuccessfulCreation()
        {
            var request = new TvEpisodeRequest()
            {
                VideoId = "tt1234",
                TvEpisodeId = "tt1233"
            };

            _service.Setup(s => s.UpsertTvEpisode(request))
                .Returns(new TvEpisodeViewModel
                {
                    Series = new SeriesViewModel
                    {
                        VideoId = "tt1234" 
                    },
                    Episode = new TvEpisode
                    {
                        VideoId = "tt1233"
                    }
                });

            var result = _controller.UpsertTvEpisode(request) as CreatedResult;

            result.Should().NotBe(null);
            result.Location.Should().Be("/videos/tvEpisodes/tt1233");
            (result.Value as TvEpisodeViewModel).Series.VideoId.Should().Be("tt1234");
            (result.Value as TvEpisodeViewModel).Episode.VideoId.Should().Be("tt1233");
        }

        [Test]
        public void ShouldReturnInternalServerErrorWhenAnyExceptionThrown()
        {
            _service.Setup(s => s.UpsertTvEpisode(It.IsAny<TvEpisodeRequest>()))
                .Throws(new Exception());

            var objectResult = _controller.UpsertTvEpisode(new TvEpisodeRequest()) as ObjectResult;
            var videoResult = objectResult.Value as ErrorResponse;
            Assert.That(videoResult, Is.Not.Null);
            Assert.That(objectResult.StatusCode, Is.EqualTo(StatusCodes.Status500InternalServerError));
            Assert.That(videoResult.Error, Is.Not.Null);
        }

        [Test]
        public void ShouldReturnNoContentWhenSuccessfulUpdate()
        {
            var request = new TvEpisodeRequest()
            {
                VideoId = "tt1234",
                TvEpisodeId = "tt1233"
            };

            _service.Setup(s => s.UpsertTvEpisode(request))
                .Returns(new TvEpisodeViewModel
                {
                    Series = new SeriesViewModel
                    {
                        VideoId = "tt1234",
                        IsUpdated = true
                    },
                    Episode = new TvEpisode
                    {
                        VideoId = "tt1234",
                        IsUpdated = true
                    }
                });

            var result = _controller.UpsertTvEpisode(request) as NoContentResult;
            result.Should().NotBeNull();

        }

    }
}
