using FluentValidation.TestHelper;
using NUnit.Framework;
using System;
using System.Linq;
using VideoDB.WebApi.Validators;

namespace VideoDB.WebApi.Tests.ValidationTests
{
    [TestFixture]
    class VideoValidatorTests
    {
        private VideoValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new VideoValidator();
        }

        [Test]
        public void ShouldFailWhenNoIdIsEntered()
        {
            _validator.ShouldHaveValidationErrorFor(
                video => video.VideoId,
                null as string);
        }

        [Test]
        public void ShouldFailWhenNoTitleIsEntered()
        {
            _validator.ShouldHaveValidationErrorFor(
                video => video.Title,
                null as string);
        }

        [Test]
        public void ShouldFailWhenNoMpaaRatingIsEntered()
        {
            _validator.ShouldHaveValidationErrorFor(
                video => video.MpaaRating,
                null as string);
        }

        [Test]
        public void ShouldFailWhenNoPlotIsEntered()
        {
            _validator.ShouldHaveValidationErrorFor(
                video => video.Plot,
                null as string);
        }
        
        [Test]
        public void ShouldFailWhenNoReleaseDateIsEntered()
        {
            _validator.ShouldHaveValidationErrorFor(
                video => video.ReleaseDate,
                DateTime.MinValue);
        }

        [Test]
        public void ShouldFailWhenIdIsTooLong()
        {
            _validator.ShouldHaveValidationErrorFor(
                video => video.VideoId,
                string.Join(string.Empty, Enumerable.Repeat('t', 33)));
        }

        [Test]
        public void ShouldNotFailWhenIdIsAtMaxSize()
        {
            _validator.ShouldNotHaveValidationErrorFor(
                video => video.VideoId,
                string.Join(string.Empty, Enumerable.Repeat('t', 32)));
        }

        [Test]
        public void ShouldFailWhenMpaaRatingIsTooLong()
        {
            _validator.ShouldHaveValidationErrorFor(
                video => video.MpaaRating,
                string.Join(string.Empty, Enumerable.Repeat('t', 9)));
        }

        [Test]
        public void ShouldNotFailWhenMpaaRatingIsAtMaxSize()
        {
            _validator.ShouldNotHaveValidationErrorFor(
                video => video.MpaaRating,
                string.Join(string.Empty, Enumerable.Repeat('t', 8)));
        }

        [Test]
        public void ShouldFailWhenRuntimeIsTooLong()
        {
            _validator.ShouldHaveValidationErrorFor(
                video => video.Runtime,
                999.995m);
        }

        [Test]
        public void ShouldNotFailWhenRuntimeIsAtMaxSize()
        {
            _validator.ShouldNotHaveValidationErrorFor(
                video => video.Runtime,
                999.994m);
        }

        [Test]
        public void ShouldFailWhenResolutionIsTooLong()
        {
            _validator.ShouldHaveValidationErrorFor(
                video => video.Resolution,
                string.Join(string.Empty, Enumerable.Repeat('t', 17)));
        }

        [Test]
        public void ShouldNotFailWhenResolutionIsAtMaxSize()
        {
            _validator.ShouldNotHaveValidationErrorFor(
                video => video.Resolution,
                string.Join(string.Empty, Enumerable.Repeat('t', 16)));
        }

        [Test]
        public void ShouldFailWhenCodecIsTooLong()
        {
            _validator.ShouldHaveValidationErrorFor(
                video => video.Codec,
                string.Join(string.Empty, Enumerable.Repeat('t', 9)));
        }

        [Test]
        public void ShouldNotFailWhenCodecIsAtMaxSize()
        {
            _validator.ShouldNotHaveValidationErrorFor(
                video => video.Codec,
                string.Join(string.Empty, Enumerable.Repeat('t', 8)));
        }

        [Test]
        public void ShouldFailWhenExtendedIsTooLong()
        {
            _validator.ShouldHaveValidationErrorFor(
                video => video.Extended,
                string.Join(string.Empty, Enumerable.Repeat('t', 17)));
        }

        [Test]
        public void ShouldNotFailWhenExtendedIsAtMaxSize()
        {
            _validator.ShouldNotHaveValidationErrorFor(
                video => video.Extended,
                string.Join(string.Empty, Enumerable.Repeat('t', 16)));
        }

        [Test]
        public void ShouldNotFailWhenResolutionIsEmpty()
        {
            _validator.ShouldNotHaveValidationErrorFor(
                video => video.Resolution,
                null as string);
        }

        [Test]
        public void ShouldNotFailWhenCodecIsEmpty()
        {
            _validator.ShouldNotHaveValidationErrorFor(
                video => video.Codec,
                null as string);
        }

        [Test]
        public void ShouldNotFailWhenRuntimeIsEmpty()
        {
            _validator.ShouldNotHaveValidationErrorFor(
                video => video.Runtime,
                null as decimal?);
        }

        [Test]
        public void ShouldNotFailWhenExtendedIsEmpty()
        {
            _validator.ShouldNotHaveValidationErrorFor(
                video => video.Extended,
                null as string);
        }
    }
}
