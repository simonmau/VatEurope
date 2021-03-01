using FluentAssertions;
using NUnit.Framework;

namespace VatEurope.Test
{
    [TestFixture]
    public sealed class DK_Tests
    {
        private readonly CountryEnum _country = CountryEnum.Denmark;

        [TestCase("DK88146328")]
        public void TestValidVat(string validVat)
        {
            _country.IsValidChecksum(validVat).Should().BeTrue();
        }

        [TestCase("nonono")]
        [TestCase("1234567890abcdefg")]
        [TestCase("DK08146328")]
        [TestCase("DK 88 1463 28")]
        public void TestInvalidVat(string invalidVat)
        {
            _country.IsValidChecksum(invalidVat).Should().BeFalse();
        }
    }
}