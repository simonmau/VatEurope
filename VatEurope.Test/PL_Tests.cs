using FluentAssertions;
using NUnit.Framework;

namespace VatEurope.Test
{
    [TestFixture]
    public sealed class PL_Tests
    {
        private readonly CountryEnum _country = CountryEnum.Poland;

        [TestCase("PL5260001246")]
        public void TestValidVat(string validVat)
        {
            _country.IsValidChecksum(validVat).Should().BeTrue();
        }

        [TestCase("nonono")]
        [TestCase("PL52600012462")]
        [TestCase("PL526000124")]
        [TestCase("PL5260001244")]
        public void TestInvalidVat(string invalidVat)
        {
            _country.IsValidChecksum(invalidVat).Should().BeFalse();
        }
    }
}