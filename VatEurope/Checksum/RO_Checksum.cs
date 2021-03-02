using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class RO_Checksum : IChecksum
    {
        private const string _regexFullString = @"^RO[0-9]{2,10}$"; //SINCE 05.12.2017 NO LEADING 0 POSSIBLE, DONT KNOW IF OLD NUMBER ARE INVALID

        public bool IsValidChecksum(string vat)
        {
            if (string.IsNullOrEmpty(vat))
            {
                return false;
            }

            return Regex.IsMatch(vat, _regexFullString);
        }
    }
}