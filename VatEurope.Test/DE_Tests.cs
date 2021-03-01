using FluentAssertions;
using NUnit.Framework;

namespace VatEurope.Test
{
    [TestFixture]
    public sealed class DE_Tests
    {
        private readonly CountryEnum _country = CountryEnum.Germany;

        [TestCase("DE111111125")]
        public void TestValidVat(string validVat)
        {
            _country.IsValidChecksum(validVat).Should().BeTrue();
        }

        [TestCase("nonono")]
        [TestCase("1234567890abcdefg")]
        [TestCase("DE011111125")]
        [TestCase("DE 11 11 111 25")]
        public void TestInvalidVat(string invalidVat)
        {
            _country.IsValidChecksum(invalidVat).Should().BeFalse();
        }
    }
}