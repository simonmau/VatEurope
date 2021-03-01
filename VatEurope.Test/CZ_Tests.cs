using FluentAssertions;
using NUnit.Framework;

namespace VatEurope.Test
{
    [TestFixture]
    public sealed class CZ_Tests
    {
        private readonly CountryEnum _country = CountryEnum.Czechia;

        [TestCase("CZ12345678")]
        [TestCase("CZ123456789")]
        [TestCase("CZ1234567890")]
        public void TestValidVat(string validVat)
        {
            _country.IsValidChecksum(validVat).Should().BeTrue();
        }

        [TestCase("nonono")]
        [TestCase("CZ1234567")]
        [TestCase("CZ12345678901")]
        public void TestInvalidVat(string invalidVat)
        {
            _country.IsValidChecksum(invalidVat).Should().BeFalse();
        }
    }
}