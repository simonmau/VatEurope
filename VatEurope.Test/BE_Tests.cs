using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace VatEurope.Test
{
    [TestFixture]
    public sealed class BE_Tests
    {
        private readonly CountryEnum _country = CountryEnum.BE;

        [TestCase("BE0776091951")]
        public void TestValidVat(string validVat)
        {
            _country.IsValidChecksum(validVat).Should().BeTrue();
        }

        [TestCase("nonono")]
        [TestCase("BE 0776091951")]
        [TestCase("BE 077 609 1951")]
        public void TestInvalidVat(string invalidVat)
        {
            _country.IsValidChecksum(invalidVat).Should().BeFalse();
        }
    }
}