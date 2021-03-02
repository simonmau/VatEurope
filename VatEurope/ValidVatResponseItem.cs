using System;

namespace VatEurope
{
    public sealed class ValidVatResponseItem
    {
        internal ValidVatResponseItem(string countryCode, string vatNumber, DateTime requestDate, string name, string address)
        {
            CountryCode = countryCode;
            VatNumber = vatNumber;
            RequestDate = requestDate;
            Name = name;
            Address = address;
        }

        public string CountryCode { get; }

        public string VatNumber { get; }

        public DateTime RequestDate { get; }

        public string Name { get; }

        public string Address { get; }

        public override string ToString()
        {
            return $"{CountryCode}{VatNumber}";
        }
    }
}