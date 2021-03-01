using FluentAssertions;
using NUnit.Framework;

namespace VatEurope.Test
{
    [TestFixture]
    public sealed class SE_Tests
    {
        private readonly CountryEnum _country = CountryEnum.Sweden;

        [TestCase("SE556188840401")]
        public void TestValidVat(string validVat)
        {
            _country.IsValidChecksum(validVat).Should().BeTrue();
        }

        [TestCase("nonono")]
        [TestCase("SE556188840400")]
        [TestCase("SE556188840495")]
        [TestCase("SE556188840301")]
        public void TestInvalidVat(string invalidVat)
        {
            _country.IsValidChecksum(invalidVat).Should().BeFalse();
        }
    }
}