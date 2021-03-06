﻿using FluentAssertions;
using NUnit.Framework;

namespace VatEurope.Test
{
    [TestFixture]
    public sealed class BE_Tests
    {
        private readonly CountryEnum _country = CountryEnum.Belgium;

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