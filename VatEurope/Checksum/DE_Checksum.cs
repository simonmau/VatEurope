using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class DE_Checksum : IChecksum
    {
        private const string _regexFullString = @"^DE[1-9][0-9]{8}$";

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

            var lastDigit = int.Parse(vat[10].ToString());

            return lastDigit == CalcCheckSum(vat.Substring(2, 8));
        }

        /// <summary>
        /// https://www.bmf.gv.at/dam/jcr:9f9f8d5f-5496-4886-aa4f-81a4e39ba83e/BMF_UID_Konstruktionsregeln.pdf
        /// </summary>
        internal static int CalcCheckSum(string numberPart)
        {
            var P = 10;

            for (int i = 0; i < numberPart.Length; i++)
            {
                var S = c(i) + P;
                var M = S % 10;

                if (M == 0)
                    M = 10;

                P = (2 * M) % 11;
            }

            var R = 11 - P;

            if (R == 10)
                return 0;

            return R;

            int c(int index)
            {
                return int.Parse(numberPart[index].ToString());
            }
        }
    }
}