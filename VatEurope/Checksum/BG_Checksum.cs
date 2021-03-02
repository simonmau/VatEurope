using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class BG_Checksum : IChecksum
    {
        private const string _regexFullString = @"^BG[0-9]{9,10}$";

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