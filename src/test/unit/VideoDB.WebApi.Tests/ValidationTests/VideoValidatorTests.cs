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


        [TestCase(0)]
        [TestCase(10)]
        public void ShouldFailIfSeriesIdIsIncorrect(int idLength)
        {
            var id = GenerateId(idLength);
            _validator.ShouldHaveValidationErrorFor(r => r.VideoId, id);
        }

        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        public void ShouldPassIfSeriesIdIsCorrect(int idLength)
        {
            var id = GenerateId(idLength);
            _validator.ShouldHaveValidationErrorFor(r => r.VideoId, id);
        }

        private string GenerateId(int length)
        {
            return "tt" + string.Join(
                string.Empty,
                Enumerable.Range(
                    new Random().Next(1000000, 999999999),
                    length));
        }
    }
}
