using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class SK_Checksum : IChecksum
    {
        private const string _regexFullString = @"^SK[1-9][0-9][234789][0-9]{7}$";

        public bool IsValidChecksum(string vat)
        {
            if (string.IsNullOrEmpty(vat))
            {
                return false;
            }

            if (!Regex.IsMatch(vat, _regexFullString))
            {
                return false;
            }

            return long.Parse(vat.Substring(2, 10)) % 11 == 0;
        }
    }
}