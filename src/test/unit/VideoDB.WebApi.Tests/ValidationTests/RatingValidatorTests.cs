using Evo.WebApi.Models.Requests;
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
    class RatingValidatorTests
    {
        private RatingValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new RatingValidator();
        }

        [Test]
        public void ShouldFailIsSourceIsEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(r => r.Source, null as string);
        }

        [Test]
        public void ShouldFailIfSourceIsTooLong()
        {
            _validator.ShouldHaveValidationErrorFor(
                r => r.Source,
                string.Join(string.Empty, Enumerable.Repeat('t', 33)));
        }

        [Test]
        public void ShouldNotFailIfSourceIsMaxLength()
        {
            _validator.ShouldNotHaveValidationErrorFor(
                r => r.Source,
                string.Join(string.Empty, Enumerable.Repeat('t', 32)));
        }

        [Test]
        public void ShouldFailIfRatingIsTooLarge()
        {
            _validator.ShouldHaveValidationErrorFor(
                r => r.RatingValue,
                100.01m);
        }

        [Test]
        public void ShouldNotFailIfRatingIsMaxSize()
        {
            _validator.ShouldNotHaveValidationErrorFor(
                r => r.RatingValue,
                100.00m);
        }
    }
}
