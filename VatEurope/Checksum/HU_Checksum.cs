using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class HU_Checksum : IChecksum
    {
        private const string _regexFullString = @"^HU[0-9]{8}$";

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

            return CalcCheckSum(vat.Substring(2, 8));
        }

        internal static bool CalcCheckSum(string numberPart)
        {
            var A1 = 9 * c(1) + 7 * c(2) + 3 * c(3) + 1 * c(4) + 9 * c(5) + 7 * c(6) + 3 * c(7);

            if (A1 % 10 == 0 && c(8) == 0)
                return true;

            return c(8) == 10 - (A1 % 10);

            int c(int index)
            {
                return int.Parse(numberPart[index - 1].ToString());
            }
        }
    }
}