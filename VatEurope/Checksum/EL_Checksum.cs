using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class EL_Checksum : IChecksum
    {
        private const string _regexFullString = @"^EL[0-9]{9}$";

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