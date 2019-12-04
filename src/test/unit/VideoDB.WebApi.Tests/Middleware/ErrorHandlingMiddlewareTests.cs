using AutoFixture;
using AutoFixture.AutoMoq;
using Evo.WebApi.Exceptions;
using Evo.WebApi.Models.ViewModels;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VideoDB.WebApi.Middleware;

namespace VideoDB.WebApi.Tests.Middleware
{
    [TestFixture]
    class ErrorHandlingMiddlewareTests
    {
        private Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
        }

        [Test]
        public async Task ShouldCallServiceIfNoException()
        {
            var isCalled = false;

            _fixture.Inject<RequestDelegate>((HttpContext context) =>
            {
                isCalled = true;
                return Task.CompletedTask;
            });
            var mw = _fixture.Create<ErrorHandlingMiddleware>();

            await mw.Invoke(new Mock<HttpContext>().Object);

            isCalled
                .Should()
                .BeTrue();
        }

        [Test]
        public async Task ShouldSetToInternalServerErrorIfGeneralException()
        {
            _fixture.Inject<RequestDelegate>((HttpContext context) =>
            {
                throw new Exception("Exception thrown!");
            });
            var mw = _fixture.Create<ErrorHandlingMiddleware>();

            var (errorResponse, statusCode) = await GetResponseFromContext(mw);

            errorResponse.Error.Should().Be("Exception thrown!");
            statusCode.Should().Be((int)HttpStatusCode.InternalServerError);
        }

        [Test]
        public async Task ShouldSetToNotFoundIfNotFoundExceptionIsThrown()
        {
            _fixture.Inject<RequestDelegate>((HttpContext context) =>
            {
                throw new EvoNotFoundException("Exception thrown!");
            });
            var mw = _fixture.Create<ErrorHandlingMiddleware>();

            var (errorResponse, statusCode) = await GetResponseFromContext(mw);

            errorResponse.Error.Should().Be("Exception thrown!");
            statusCode.Should().Be((int)HttpStatusCode.NotFound);

        }

        [Test]
        public async Task ShouldSetToBadRequestIfBadRequestExceptionIsThrown()
        {
            _fixture.Inject<RequestDelegate>((HttpContext context) =>
            {
                throw new EvoBadRequestException("Exception thrown!");
            });
            var mw = _fixture.Create<ErrorHandlingMiddleware>();

            var (errorResponse, statusCode) = await GetResponseFromContext(mw);

            errorResponse.Error.Should().Be("Exception thrown!");
            statusCode.Should().Be((int)HttpStatusCode.BadRequest);

        }

        private async Task<(ErrorResponse errorResponse, int statusCode)> GetResponseFromContext(ErrorHandlingMiddleware mw)
        {
            var context = new DefaultHttpContext();
            using var memoryStream = new MemoryStream();
            context.Response.Body = memoryStream;

            await mw.Invoke(context);
            memoryStream.Position = 0;

            using var reader = new StreamReader(memoryStream);
            var content = reader.ReadToEnd();
            var response = JsonConvert.DeserializeObject<ErrorResponse>(content);

            return (response, context.Response.StatusCode);
        }
    }
}
