using FluentAssertions;
using NUnit.Framework;

namespace VatEurope.Test
{
    [TestFixture]
    public sealed class IE_Tests
    {
        private readonly CountryEnum _country = CountryEnum.Ireland;

        [TestCase("IE8Z49289F")]
        [TestCase("IE3628739L")]
        [TestCase("IE3628739UA")]
        public void TestValidVat(string validVat)
        {
            _country.IsValidChecksum(validVat).Should().BeTrue();
        }

        [TestCase("nonono")]
        [TestCase("IE8Z49289")]
        [TestCase("IE3628739")]
        [TestCase("IE3628739A")]
        [TestCase("IE8Z49289D")]
        [TestCase("IE3628739D")]
        [TestCase("IE3628739FA")]
        [TestCase("IE8Z49289D2")]
        [TestCase("IE3628739D3")]
        [TestCase("IE3628739FA1")]
        public void TestInvalidVat(string invalidVat)
        {
            _country.IsValidChecksum(invalidVat).Should().BeFalse();
        }
    }
}