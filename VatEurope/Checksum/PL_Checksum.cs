using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class PL_Checksum : IChecksum
    {
        private const string _regexFullString = @"^PL[0-9]{10}$";

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

            var digit10 = int.Parse(vat.Substring(11, 1));

            return digit10 == CalcCheckSum(vat.Substring(2, 9));
        }

        internal static int CalcCheckSum(string numberPart)
        {
            var A1 = 6 * c(1) + 5 * c(2) + 7 * c(3) + 2 * c(4) + 3 * c(5) + 4 * c(6) + 5 * c(7) + 6 * c(8) + 7 * c(9);

            return A1 % 11;

            int c(int index)
            {
                return int.Parse(numberPart[index - 1].ToString());
            }
        }
    }
}