using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class LU_Checksum : IChecksum
    {
        private const string _regexFullString = @"^LU[0-9]{8}$";

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

            var lastDigits = int.Parse(vat.Substring(8, 2));

            return lastDigits == CalcCheckSum(vat.Substring(2, 6));
        }

        internal static int CalcCheckSum(string numberPart)
        {
            return int.Parse(numberPart) % 89;
        }
    }
}