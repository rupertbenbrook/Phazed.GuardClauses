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

        [Test]
        [TestCase(0, 1, 1)]
        [TestCase(1, 2, 2)]
        [TestCase(2, 0, 1)]
        [TestCase(0d, 1d, 1d)]
        [TestCase(1d, 2d, 2d)]
        [TestCase(2d, 0d, 1d)]
        [TestCase(0d, 0.000000000000000000000000000000000000000000000000000001d, 1d)]
        [TestCase("a", "b", "c")]
        [TestCase("a", "A", "B")]
        public void AgainstOutOfRange_Comparable_ThrowsArgumentOutOfRangeException<T>(T value, T min, T max) where T : IComparable
        {
            Assert.That(
                () => Guard.AgainstOutOfRange(value, min, max, "param"),
                Throws.TypeOf<ArgumentOutOfRangeException>().With.Property("ParamName").EqualTo("param")
                    .And.Property("Message").StartsWith("Value must be between " + min + " and " + max + "."));
        }

        [Test]
        [TestCase(1, 1, 1)]
        [TestCase(0, 0, 1)]
        [TestCase(2, 0, 2)]
        [TestCase(0, -1, 1)]
        [TestCase(1d, 1d, 1d)]
        [TestCase(0d, 0d, 1d)]
        [TestCase(2d, 0d, 2d)]
        [TestCase(0d, -1d, 1d)]
        [TestCase(0.000000000000000000000000000000000000000000000000000001d, 0, 1d)]
        [TestCase("a", "a", "b")]
        [TestCase("A", "A", "B")]
        public void AgainstOutOfRange_Comparable_DoesNotThrow<T>(T value, T min, T max) where T : IComparable
        {
            Assert.That(
                () => Guard.AgainstOutOfRange(value, min, max, "param"),
                Throws.Nothing);
        }

        [Test]
        public void AgainstOutOfRange_Null_ThrowsArgumentNullException()
        {
            Assert.That(
                () => Guard.AgainstOutOfRange(null, "", "", "param"),
                Throws.TypeOf<ArgumentNullException>().With.Property("ParamName").EqualTo("param")
                    .And.Property("Message").StartsWith("Value cannot be null."));
        }
    }
}
