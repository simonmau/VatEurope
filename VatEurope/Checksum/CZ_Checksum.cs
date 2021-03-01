using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class CZ_Checksum : IChecksum
    {
        private const string _regexFullString = @"^CZ[0-9]{8,10}$";

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