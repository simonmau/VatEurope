using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class CY_Checksum : IChecksum
    {
        private const string _regexFullString = @"^CY[0-9]{8}[A-Z0-9]$";

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