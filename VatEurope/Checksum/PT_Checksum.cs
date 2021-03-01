using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class PT_Checksum : IChecksum
    {
        private const string _regexFullString = @"^PT[1-9][0-9]{8}$";

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
            var R = 11 - ((9 * c(1) + 8 * c(2) + 7 * c(3) + 6 * c(4) + 5 * c(5) + 4 * c(6) + 3 * c(7) + 2 * c(8)) % 11);

            if (R == 10 || R == 11)
            {
                R = 0;
            }
            return R;

            int c(int index)
            {
                return int.Parse(numberPart[index - 1].ToString());
            }
        }
    }
}