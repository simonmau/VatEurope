using Enum.Ext;
using System;
using System.Collections.Generic;
using System.Text;
using VatEurope.Checksum;

namespace VatEurope
{
    public sealed class CountryEnum : TypeSafeEnum<CountryEnum, int>, IChecksum
    {
        public static readonly CountryEnum AT = new CountryEnum(1, "AT", new AT_Checksum());
        public static readonly CountryEnum BE = new CountryEnum(2, "BE", new BE_Checksum());
        public static readonly CountryEnum HR = new CountryEnum(3, "HR", new HR_Checksum());

        private CountryEnum(int id, string code, IChecksum checksum) : base(id)
        {
            Code = code;
            _checksum = checksum;
        }

        private IChecksum _checksum;

        public string Code { get; private set; }

        public bool IsValidChecksum(string vat) => _checksum.IsValidChecksum(vat);
    }
}