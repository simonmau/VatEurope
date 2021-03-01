using FluentAssertions;
using NUnit.Framework;

namespace VatEurope.Test
{
    [TestFixture]
    public sealed class EE_Tests
    {
        private readonly CountryEnum _country = CountryEnum.Estonia;

        [TestCase("EE100207415")]
        public void TestValidVat(string validVat)
        {
            _country.IsValidChecksum(validVat).Should().BeTrue();
        }

        [TestCase("nonono")]
        [TestCase("EE100207414")]
        [TestCase("EE100207416")]
        [TestCase("EEA00207415")]
        public void TestInvalidVat(string invalidVat)
        {
            _country.IsValidChecksum(invalidVat).Should().BeFalse();
        }
    }
}