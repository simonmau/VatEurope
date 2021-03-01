using FluentAssertions;
using NUnit.Framework;

namespace VatEurope.Test
{
    [TestFixture]
    public sealed class AT_Tests
    {
        private readonly CountryEnum _country = CountryEnum.Austria;

        [TestCase("ATU73952234")]
        [TestCase("ATU73519007")]
        [TestCase("ATU67104705")]
        public void TestValidVat(string validVat)
        {
            _country.IsValidChecksum(validVat).Should().BeTrue();
        }

        [TestCase("nonono")]
        [TestCase("1234567890abcdefg")]
        [TestCase("Atu12345678")]
        [TestCase("ATU 12 345 678")]
        [TestCase("ATU12345678 ")]
        [TestCase("ATU12345678")]
        public void TestInvalidVat(string invalidVat)
        {
            _country.IsValidChecksum(invalidVat).Should().BeFalse();
        }
    }
}