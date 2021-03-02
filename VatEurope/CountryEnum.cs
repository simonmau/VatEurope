using Enum.Ext;
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
        public static readonly CountryEnum Netherlands = new CountryEnum(12, "NL", new NL_Checksum());
        public static readonly CountryEnum Portugal = new CountryEnum(13, "PT", new PT_Checksum());
        public static readonly CountryEnum Sweden = new CountryEnum(14, "SE", new SE_Checksum());
        public static readonly CountryEnum Cyprus = new CountryEnum(15, "CY", new CY_Checksum());
        public static readonly CountryEnum Czechia = new CountryEnum(16, "CZ", new CZ_Checksum());
        public static readonly CountryEnum Estonia = new CountryEnum(17, "EE", new EE_Checksum());
        public static readonly CountryEnum Hungary = new CountryEnum(18, "HU", new HU_Checksum());
        public static readonly CountryEnum Lithuania = new CountryEnum(19, "LT", new LT_Checksum());
        public static readonly CountryEnum Latvia = new CountryEnum(20, "LV", new LV_Checksum());
        public static readonly CountryEnum Malta = new CountryEnum(21, "MT", new MT_Checksum());
        public static readonly CountryEnum Poland = new CountryEnum(22, "PL", new PL_Checksum());
        public static readonly CountryEnum Slovenia = new CountryEnum(23, "SI", new SI_Checksum());
        public static readonly CountryEnum Slovakia = new CountryEnum(24, "SK", new SK_Checksum());
        public static readonly CountryEnum Bulgaria = new CountryEnum(25, "BG", new BG_Checksum());
        public static readonly CountryEnum Romania = new CountryEnum(26, "RO", new RO_Checksum());
        public static readonly CountryEnum HR = new CountryEnum(27, "HR", new HR_Checksum());

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