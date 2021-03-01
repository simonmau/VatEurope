using FluentAssertions;
using NUnit.Framework;

namespace VatEurope.Test
{
    [TestFixture]
    public sealed class ES_Tests
    {
        private readonly CountryEnum _country = CountryEnum.Spain;

        [TestCase("ESX9999999X")]
        public void TestValidVat(string validVat)
        {
            _country.IsValidChecksum(validVat).Should().BeTrue();
        }

        [TestCase("nonono")]
        [TestCase("HR9999999999a")]
        [TestCase("HR 9999 99999 99")]
        [TestCase("HR 9999 99999 99")]
        public void TestInvalidVat(string invalidVat)
        {
            _country.IsValidChecksum(invalidVat).Should().BeFalse();
        }
    }
}