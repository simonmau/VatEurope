using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class FR_Checksum : IChecksum
    {
        private const string _regexFullString = @"^FR[A-Z0-9]{2}[0-9]{9}$";

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