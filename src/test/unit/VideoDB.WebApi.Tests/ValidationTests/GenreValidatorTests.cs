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
    class GenreValidatorTests
    {
        private GenreValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new GenreValidator();
        }

        [Test]
        public void ShouldFailIfNoNameEntered()
        {
            _validator.ShouldHaveValidationErrorFor(r => r.Name, null as string);
        }

        [Test]
        public void ShouldFailIfNameIsTooLong()
        {
            _validator.ShouldHaveValidationErrorFor(
                r => r.Name,
                string.Join('t', Enumerable.Repeat('t', 33)));
        }

        [Test]
        public void ShouldNotFailIfNameIsMaxLength()
        {
            _validator.ShouldHaveValidationErrorFor(
                r => r.Name,
                string.Join('t', Enumerable.Repeat('t', 32)));
        }

    }
}
