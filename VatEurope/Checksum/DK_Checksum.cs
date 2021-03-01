using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class DK_Checksum : IChecksum
    {
        private const string _regexFullString = @"^DK[1-9][0-9]{7}$";

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
            var sum = 2 * c(1) + 7 * c(2) + 6 * c(3) + 5 * c(4) + 4 * c(5) + 3 * c(6) + 2 * c(7) + c(8);

            return sum % 11 == 0;

            int c(int index)
            {
                return int.Parse(numberPart[index - 1].ToString());
            }
        }
    }
}