﻿using Enum.Ext;
using System;
using System.Collections.Generic;
using System.Text;
using VatEurope.Checksum;

namespace VatEurope
{
    public sealed class CountryEnum : TypeSafeEnum<CountryEnum, int>, IChecksum
    {
        public static readonly CountryEnum Austria = new CountryEnum(1, "AT", new AT_Checksum());
        public static readonly CountryEnum Belgium = new CountryEnum(2, "BE", new BE_Checksum());
        public static readonly CountryEnum Germany = new CountryEnum(3, "DE", new DE_Checksum());
        public static readonly CountryEnum Denmark = new CountryEnum(4, "DK", new DK_Checksum());
        public static readonly CountryEnum Greece = new CountryEnum(5, "EL", new EL_Checksum());
        public static readonly CountryEnum Spain = new CountryEnum(6, "ES", new ES_Checksum());
        public static readonly CountryEnum Finland = new CountryEnum(7, "FI", new FI_Checksum());
        public static readonly CountryEnum French = new CountryEnum(8, "FR", new FR_Checksum());

        //public static readonly CountryEnum Ireland = new CountryEnum(9, "IE", new IE_Checksum());
        public static readonly CountryEnum Italy = new CountryEnum(10, "IT", new IT_Checksum());

        public static readonly CountryEnum Luxembourg = new CountryEnum(11, "LU", new LU_Checksum());

        //NEXT SEITE 14

        public static readonly CountryEnum HR = new CountryEnum(999, "HR", new HR_Checksum());

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