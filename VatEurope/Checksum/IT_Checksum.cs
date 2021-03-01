using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class IT_Checksum : IChecksum
    {
        private const string _regexFullString = @"^IT[0-9]{11}$";

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

            if (!CalcRule(vat.Substring(9, 3)))
            {
                return false;
            }

            var lastDigit = int.Parse(vat[12].ToString());

            return lastDigit == CalcCheckSum(vat.Substring(2, 10));
        }

        internal static bool CalcRule(string numberPart)
        {
            var value = int.Parse(numberPart);

            if (value > 0 && value < 101)
                return true;

            if (value == 120 || value == 121 || value == 999 || value == 888)
                return true;

            return false;
        }

        internal static int CalcCheckSum(string numberPart)
        {
            var S1 = c(1) + c(3) + c(5) + c(7) + c(9);
            var S2 = d(2) + d(4) + d(6) + d(8) + d(10);

            return (10 - ((S1 + S2) % 10)) % 10;

            int c(int index)
            {
                return int.Parse(numberPart[index - 1].ToString());
            }

            int d(int index)
            {
                var div = c(index) / 5;
                return div + ((2 * c(index)) % 10);
            }
        }
    }
}