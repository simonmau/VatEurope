using FluentAssertions;
using NUnit.Framework;

namespace VatEurope.Test
{
    [TestFixture]
    public sealed class LT_Tests
    {
        private readonly CountryEnum _country = CountryEnum.Lithuania;

        [TestCase("LT213179412")]
        [TestCase("LT290061371314")]
        public void TestValidVat(string validVat)
        {
            _country.IsValidChecksum(validVat).Should().BeTrue();
        }

        [TestCase("nonono")]
        [TestCase("LT29006137134")]
        [TestCase("LT21379412")]
        public void TestInvalidVat(string invalidVat)
        {
            _country.IsValidChecksum(invalidVat).Should().BeFalse();
        }
    }
}