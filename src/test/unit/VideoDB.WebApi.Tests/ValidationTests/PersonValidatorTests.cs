using Evo.WebApi.Models.Enums;
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
    class PersonValidatorTests
    {
        private PersonValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new PersonValidator();
        }

        [Test]
        public void ShouldReturnErrorIfNoFirstNameEntered()
        {
            _validator.ShouldHaveValidationErrorFor(r => r.FirstName, null as string);
        }

        [Test]
        public void ShouldReturnErrorIfNoRoleEntered()
        {
            _validator.ShouldHaveValidationErrorFor(r => r.Role, PersonType.None);
        }

        [Test]
        public void ShouldNotHaveErrorIfMiddleNameIsEmpty()
        {
            _validator.ShouldNotHaveValidationErrorFor(r => r.MiddleName, null as string);
        }

        [Test]
        public void ShouldNotHaveErrorIfLastNameIsEmpty()
        {
            _validator.ShouldNotHaveValidationErrorFor(r => r.LastName, null as string);
        }

        [Test]
        public void ShouldNotHaveErrorIfSuffixIsEmpty()
        {
            _validator.ShouldNotHaveValidationErrorFor(r => r.Suffix, null as string);
        }

        [Test]
        public void ShouldFailIfFirstNameIsTooLong()
        {
            _validator.ShouldHaveValidationErrorFor(
                r => r.FirstName,
                string.Join(string.Empty, Enumerable.Repeat('t', 65)));
        }

        [Test]
        public void ShouldFailIfMiddleNameIsTooLong()
        {
            _validator.ShouldHaveValidationErrorFor(
                r => r.MiddleName,
                string.Join(string.Empty, Enumerable.Repeat('t', 65)));
        }

        [Test]
        public void ShouldFailIfLastNameIsTooLong()
        {
            _validator.ShouldHaveValidationErrorFor(
                r => r.LastName,
                string.Join(string.Empty, Enumerable.Repeat('t', 65)));
        }

        [Test]
        public void ShouldFailIfSuffixIsTooLong()
        {
            _validator.ShouldHaveValidationErrorFor(
                r => r.Suffix,
                string.Join(string.Empty, Enumerable.Repeat('t', 65)));
        }

        [Test]
        public void ShouldNotFailIfFirstNameIsMaxLength()
        {
            _validator.ShouldNotHaveValidationErrorFor(
                r => r.FirstName,
                string.Join(string.Empty, Enumerable.Repeat('t', 64)));
        }

        [Test]
        public void ShouldNotFailIfMiddleNameIsMaxLength()
        {
            _validator.ShouldNotHaveValidationErrorFor(
                r => r.MiddleName,
                string.Join(string.Empty, Enumerable.Repeat('t', 64)));
        }

        [Test]
        public void ShouldNotFailIfLastNameIsMaxLength()
        {
            _validator.ShouldNotHaveValidationErrorFor(
                r => r.LastName,
                string.Join(string.Empty, Enumerable.Repeat('t', 64)));
        }

        [Test]
        public void ShouldNotFailIfSuffixIsMaxLength()
        {
            _validator.ShouldNotHaveValidationErrorFor(
                r => r.Suffix,
                string.Join(string.Empty, Enumerable.Repeat('t', 64)));
        }
    }
}
