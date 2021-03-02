using FluentAssertions;
using NUnit.Framework;

namespace VatEurope.Test
{
    [TestFixture]
    public sealed class SI_Tests
    {
        private readonly CountryEnum _country = CountryEnum.Slovenia;

        [TestCase("SI15012557")]
        public void TestValidVat(string validVat)
        {
            _country.IsValidChecksum(validVat).Should().BeTrue();
        }

        [TestCase("nonono")]
        [TestCase("SI1501255")]
        [TestCase("SI150125577")]
        [TestCase("SI15012556")]
        public void TestInvalidVat(string invalidVat)
        {
            _country.IsValidChecksum(invalidVat).Should().BeFalse();
        }
    }
}