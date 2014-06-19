using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Phazed.GuardClauses.UnitTests
{
    [TestFixture]
    public class GuardTests
    {
        [Test]
        public void AgainstNull_Null_ThrowsArgumentNullException()
        {
            Assert.That(
                () => Guard.AgainstNull(null, "param"),
                Throws.TypeOf<ArgumentNullException>().With.Property("ParamName").EqualTo("param")
                    .And.Property("Message").StartsWith("Value cannot be null."));
        }

        [Test]
        public void AgainstNull_NotNull_DoesNotThrow()
        {
            Assert.That(
                () => Guard.AgainstNull(new object(), "param"),
                Throws.Nothing);
        }

        [Test]
        public void AgainstEmpty_EmptyString_ThrowsArgumentException()
        {
            Assert.That(
                () => Guard.AgainstEmpty("", "param"),
                Throws.TypeOf<ArgumentException>().With.Property("ParamName").EqualTo("param")
                    .And.Property("Message").StartsWith("Value cannot be empty."));
        }

        [Test]
        public void AgainstEmpty_NullString_ThrowsArgumentException()
        {
            Assert.That(
                () => Guard.AgainstEmpty((string)null, "param"),
                Throws.TypeOf<ArgumentNullException>().With.Property("ParamName").EqualTo("param")
                    .And.Property("Message").StartsWith("Value cannot be null."));
        }

        [Test]
        public void AgainstEmpty_NonEmptyString_DoesNotThrow()
        {
            Assert.That(
                () => Guard.AgainstEmpty("notempty", "param"),
                Throws.Nothing);
        }

        [Test]
        public void AgainstEmpty_EmptyList_ThrowsArgumentException()
        {
            Assert.That(
                () => Guard.AgainstEmpty(new List<string>(), "param"),
                Throws.TypeOf<ArgumentException>().With.Property("ParamName").EqualTo("param")
                    .And.Property("Message").StartsWith("Value cannot be empty."));
        }

        [Test]
        public void AgainstEmpty_NullList_ThrowsArgumentNullException()
        {
            Assert.That(
                () => Guard.AgainstEmpty((List<string>)null, "param"),
                Throws.TypeOf<ArgumentNullException>().With.Property("ParamName").EqualTo("param")
                    .And.Property("Message").StartsWith("Value cannot be null."));
        }

        [Test]
        public void AgainstEmpty_NonEmptyList_DoesNotThrow()
        {
            Assert.That(
                () => Guard.AgainstEmpty(new List<string> { "notempty" }, "param"),
                Throws.Nothing);
        }
    }
}
