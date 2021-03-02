using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class LV_Checksum : IChecksum
    {
        private const string _regexFullString = @"^LV[0-9]{11}$";

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