using FluentAssertions;
using NUnit.Framework;

namespace VatEurope.Test
{
    [TestFixture]
    public sealed class HU_Tests
    {
        private readonly CountryEnum _country = CountryEnum.Hungary;

        [TestCase("HU21376414")]
        [TestCase("HU10597190")]
        public void TestValidVat(string validVat)
        {
            _country.IsValidChecksum(validVat).Should().BeTrue();
        }

        [TestCase("nonono")]
        [TestCase("HU21376410")]
        [TestCase("HU10597191")]
        public void TestInvalidVat(string invalidVat)
        {
            _country.IsValidChecksum(invalidVat).Should().BeFalse();
        }
    }
}