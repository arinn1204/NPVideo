﻿using Evo.WebApi.Models.Requests;
using FluentValidation;
using FluentValidation.TestHelper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoDB.WebApi.Validators;

namespace VideoDB.WebApi.Tests.ValidationTests
{
    [TestFixture]
    class TvEpisodeValidatorTests
    {
        private TvEpisodeValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new TvEpisodeValidator();
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

        [TestCase(0)]
        [TestCase(10)]
        public void ShouldFailIfEpisodeIdIsIncorrect(int idLength)
        {
            var id = GenerateId(idLength);
            _validator.ShouldHaveValidationErrorFor(r => r.TvEpisodeId, id);
        }

        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        public void ShouldPassIfEpisodeIdIsCorrect(int idLength)
        {
            var id = GenerateId(idLength);
            _validator.ShouldHaveValidationErrorFor(r => r.TvEpisodeId, id);
        }


        [Test]
        public void ShouldFailIfSeriesTitleIsEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(r => r.Title, null as string);
        }

        [TestCase("")]
        [TestCase("asdfghjkl")]
        public void ShouldFailIfRatingIsIncorrect(string rating)
        {
            _validator.ShouldHaveValidationErrorFor(r => r.MpaaRating, rating);
        }

        [Test]
        public void ShouldNotFailIfRatingIsCorrect()
        {
            _validator.ShouldNotHaveValidationErrorFor(
                r => r.MpaaRating,
                string.Join(string.Empty, Enumerable.Repeat('t', 8)));
        }

        [Test]
        public void ShouldFailIfPlotIsEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(r => r.Plot, null as string);
        }

        [Test]
        public void ShouldFailIfSeriesReleaseDateIsEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(r => r.ReleaseDate, default(DateTime));
        }

        [TestCase(0)]
        [TestCase(999.945)]
        public void ShouldFailIfRuntimeIsIncorrect(decimal runtime)
        {
            _validator.ShouldHaveValidationErrorFor(r => r.Runtime, runtime);
        }

        [Test]
        public void ShouldNotFailIfRuntimeIsMaxSize()
        {
            _validator.ShouldNotHaveValidationErrorFor(r => r.Runtime, 999.9449m);
        }

        [Test]
        public void ShouldFailIfEpisodeReleaseDateIsEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(r => r.EpisodeReleaseDate, default(DateTime));
        }

        [Test]
        public void ShouldFailIfEpisodeNumberIsZero()
        {
            _validator.ShouldHaveValidationErrorFor(r => r.EpisodeNumber, 0);
        }

        [Test]
        public void ShouldFailIfSeasonNumberIsZero()
        {
            _validator.ShouldHaveValidationErrorFor(r => r.SeasonNumber, 0);
        }

        [Test]
        public void ShouldFailIfEpisodeNameIsEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(r => r.EpisodeName, null as string);
        }

        [Test]
        public void ShouldFailIfEpisodePlotIsEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(r => r.EpisodePlot, null as string);
        }

        [TestCase("")]
        [TestCase("ffffffffffffffff")]
        public void ShouldNotFailIfResolutionIsCorrect(string resolution)
        {
            _validator.ShouldNotHaveValidationErrorFor(r => r.Resolution, resolution);
        }

        [Test]
        public void ShouldFailIfResolutionIsTooLarge()
        {
            _validator.ShouldHaveValidationErrorFor(
                r => r.Resolution,
                string.Join(string.Empty, Enumerable.Repeat('t', 17)));
        }

        [TestCase("")]
        [TestCase("ffffffffffffffff")]
        public void ShouldNotFailIfExtendedIsCorrect(string extended)
        {
            _validator.ShouldNotHaveValidationErrorFor(r => r.Extended, extended);
        }

        [Test]
        public void ShouldFailIfExtendedIsTooLarge()
        {
            _validator.ShouldHaveValidationErrorFor(
                r => r.Extended,
                string.Join(string.Empty, Enumerable.Repeat('t', 17)));
        }

        [TestCase("")]
        [TestCase("ffffffff")]
        public void ShouldNotFailIfCodecIsCorrect(string codec)
        {
            _validator.ShouldNotHaveValidationErrorFor(r => r.Codec, codec);
        }

        [Test]
        public void ShouldFailIfCodecIsTooLarge()
        {
            _validator.ShouldHaveValidationErrorFor(
                r => r.Codec,
                string.Join(string.Empty, Enumerable.Repeat('t', 9)));
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
