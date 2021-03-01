using FluentAssertions;
using NUnit.Framework;

namespace VatEurope.Test
{
    [TestFixture]
    public sealed class NL_Tests
    {
        private readonly CountryEnum _country = CountryEnum.Netherlands;

        [TestCase("NL010000446B01")]
        public void TestValidVat(string validVat)
        {
            _country.IsValidChecksum(validVat).Should().BeTrue();
        }

        [TestCase("nonono")]
        [TestCase("NLA0000356")]
        [TestCase("NLa10000446B01")]
        [TestCase("NL010000446B00")]
        public void TestInvalidVat(string invalidVat)
        {
            _country.IsValidChecksum(invalidVat).Should().BeFalse();
        }
    }
}