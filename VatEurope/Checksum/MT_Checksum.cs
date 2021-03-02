using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class MT_Checksum : IChecksum
    {
        private const string _regexFullString = @"^MT[0-9]{8}$";

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