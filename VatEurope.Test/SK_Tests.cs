using FluentAssertions;
using NUnit.Framework;

namespace VatEurope.Test
{
    [TestFixture]
    public sealed class SK_Tests
    {
        private readonly CountryEnum _country = CountryEnum.Slovakia;

        [TestCase("SK4030000007")]
        public void TestValidVat(string validVat)
        {
            _country.IsValidChecksum(validVat).Should().BeTrue();
        }

        [TestCase("nonono")]
        [TestCase("SK403000000")]
        [TestCase("SK40300000077")]
        [TestCase("SK4030000003")]
        [TestCase("SK5407062531")]
        public void TestInvalidVat(string invalidVat)
        {
            _country.IsValidChecksum(invalidVat).Should().BeFalse();
        }
    }
}