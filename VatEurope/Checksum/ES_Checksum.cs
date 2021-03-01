using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class ES_Checksum : IChecksum
    {
        private const string _regexFullString = @"^ES[A-Z0-9][0-9]{7}[A-Z0-9]$";

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