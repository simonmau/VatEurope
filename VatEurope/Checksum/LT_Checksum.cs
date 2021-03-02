using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class LT_Checksum : IChecksum
    {
        private const string _regexFullStringV1 = @"^LT[0-9]{7}1[0-9]$";
        private const string _regexFullStringV2 = @"^LT[0-9]{10}1[0-9]$";

        public bool IsValidChecksum(string vat)
        {
            if (string.IsNullOrEmpty(vat))
            {
                return false;
            }

            if (Regex.IsMatch(vat, _regexFullStringV1))
            {
                var lastDigit = int.Parse(vat.Substring(10, 1));

                return lastDigit == CalcCheckSumV1(vat.Substring(2, 8));
            }

            if (Regex.IsMatch(vat, _regexFullStringV2))
            {
                var lastDigit = int.Parse(vat.Substring(13, 1));

                return lastDigit == CalcCheckSumV2(vat.Substring(2, 11));
            }

            return false;
        }

        internal static int CalcCheckSumV1(string numberPart)
        {
            var A1 = 1 * c(1) + 2 * c(2) + 3 * c(3) + 4 * c(4) + 5 * c(5) + 6 * c(6) + 7 * c(7) + 8 * c(8);
            var R1 = A1 % 11;

            if (R1 != 10)
            {
                return R1;
            }
            else
            {
                var A2 = 3 * c(1) + 4 * c(2) + 5 * c(3) + 6 * c(4) + 7 * c(5) + 8 * c(6) + 9 * c(7) + 1 * c(8);
                var R2 = A2 % 11;

                if (R2 == 10)
                {
                    return 0;
                }
                else
                {
                    return R2;
                }
            }

            int c(int index)
            {
                return int.Parse(numberPart[index - 1].ToString());
            }
        }

        internal static int CalcCheckSumV2(string numberPart)
        {
            var A1 = 1 * c(1) + 2 * c(2) + 3 * c(3) + 4 * c(4) + 5 * c(5) + 6 * c(6)
                + 7 * c(7) + 8 * c(8) + 9 * c(9) + 1 * c(10) + 2 * c(11);
            var R1 = A1 % 11;

            if (R1 != 10)
            {
                return R1;
            }
            else
            {
                var A2 = 3 * c(1) + 4 * c(2) + 5 * c(3) + 6 * c(4)
                    + 7 * c(5) + 8 * c(6) + 9 * c(7) + 1 * c(8) + 2 * c(9) + 3 * c(10) + 4 * c(11);
                var R2 = A2 % 11;

                if (R2 == 10)
                {
                    return 0;
                }
                else
                {
                    return R2;
                }
            }

            int c(int index)
            {
                return int.Parse(numberPart[index - 1].ToString());
            }
        }
    }
}