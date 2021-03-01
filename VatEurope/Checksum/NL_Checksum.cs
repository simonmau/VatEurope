using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class NL_Checksum : IChecksum
    {
        private const string _regexFullString = @"^NL[0-9]{9}B[0-9]{2}$";

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

            if (int.Parse(vat.Substring(12, 2)) == 0)
            {
                return false;
            }

            var digit9 = int.Parse(vat.Substring(10, 1));

            return digit9 == CalcCheckSum(vat.Substring(2, 8));
        }

        internal static int CalcCheckSum(string numberPart)
        {
            var A1 = c(1) * 9 + c(2) * 8 + c(3) * 7 + c(4) * 6 + c(5) * 5 + c(6) * 4 + c(7) * 3 + c(8) * 2;
            var A2 = A1 % 11;

            //USELESS; ONLY 1 DIGIT IS COMPARED
            //if (A2 == 10)
            //return -1;

            return A2;

            int c(int index)
            {
                return int.Parse(numberPart[index - 1].ToString());
            }
        }
    }
}