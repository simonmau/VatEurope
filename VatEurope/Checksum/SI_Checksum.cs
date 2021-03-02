using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class SI_Checksum : IChecksum
    {
        private const string _regexFullString = @"^SI[1-9][0-9]{7}$";

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

            var digit9 = int.Parse(vat.Substring(9, 1));

            return CalcCheckSum(vat.Substring(2, 7), digit9);
        }

        internal static bool CalcCheckSum(string numberPart, int lastDigit)
        {
            var A1 = c(1) * 8 + c(2) * 7 + c(3) * 6 + c(4) * 5 + c(5) * 4 + c(6) * 3 + c(7) * 2;
            var R = 11 - (A1 % 11);

            if (R == 10)
            {
                return lastDigit == 0;
            }
            else if (R == 11)
            {
                return false;
            }
            else
            {
                return R == lastDigit;
            }

            int c(int index)
            {
                return int.Parse(numberPart[index - 1].ToString());
            }
        }
    }
}