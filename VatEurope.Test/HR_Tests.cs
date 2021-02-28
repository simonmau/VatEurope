using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace VatEurope.Test
{
    [TestFixture]
    public sealed class HR_Tests
    {
        private readonly CountryEnum _country = CountryEnum.HR;

        [TestCase("HR99999999999")]
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