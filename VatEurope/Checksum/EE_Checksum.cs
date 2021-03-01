using System;
using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class EE_Checksum : IChecksum
    {
        private const string _regexFullString = @"^EE10[0-9]{7}$";

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

            var digit9 = int.Parse(vat.Substring(10, 1));

            return digit9 == CalcCheckSum(vat.Substring(2, 8));
        }

        internal static int CalcCheckSum(string numberPart)
        {
            var A1 = 3 * c(1) + 7 * c(2) + 1 * c(3) + 3 * c(4) + 7 * c(5) + 1 * c(6) + 3 * c(7) + 7 * c(8);
            var A2 = A1 + (10 - (A1 % 10));
            return A2 - A1;

            int c(int index)
            {
                return int.Parse(numberPart[index - 1].ToString());
            }
        }
    }
}