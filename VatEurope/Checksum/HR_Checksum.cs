using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class HR_Checksum : IChecksum
    {
        private const string _regexFullString = @"^HR[0-9]{11}$";

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

            return true;
        }
    }
}