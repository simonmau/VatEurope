using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class FI_Checksum : IChecksum
    {
        private const string _regexFullString = @"^FI[0-9]{8}$";

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

            var lastDigit = int.Parse(vat[9].ToString());

            return CalcCheckSum(vat.Substring(2, 7), lastDigit);
        }

        internal static bool CalcCheckSum(string numberPart, int lastDigit)
        {
            var r = 11 - (7 * c(1) + 9 * c(2) + 10 * c(3) + 5 * c(4) + 8 * c(5) + 4 * c(6) + 2 * c(7)) % 11;

            if (r == 10)
                return false;

            if (r == 11)
                return lastDigit == 8;

            return r == lastDigit;

            int c(int index)
            {
                return int.Parse(numberPart[index - 1].ToString());
            }
        }
    }
}