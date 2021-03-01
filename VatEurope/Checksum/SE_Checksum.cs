using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class SE_Checksum : IChecksum
    {
        private const string _regexFullString = @"^SE[0-9]{12}$";

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

            var firstCheck = int.Parse(vat.Substring(12, 2));

            if (firstCheck < 1 || firstCheck > 94)
            {
                return false;
            }

            var digit10 = int.Parse(vat.Substring(11, 1));

            return digit10 == CalcCheckSum(vat.Substring(2, 9));
        }

        internal static int CalcCheckSum(string numberPart)
        {
            var R = s(1) + s(3) + s(5) + s(7) + s(9);

            return (10 - (R + c(2) + c(4) + c(6) + c(8)) % 10) % 10;

            int c(int index)
            {
                return int.Parse(numberPart[index - 1].ToString());
            }

            int s(int index)
            {
                int cVal = c(index) / 5;
                return cVal + ((c(index) * 2) % 10);
            }
        }
    }
}