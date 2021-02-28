using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class AT_Checksum : IChecksum
    {
        private const string _regexFullString = @"^ATU[0-9]{8}$";

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

            return lastDigit == CalcCheckSum(vat.Substring(3));
        }

        /// <summary>
        /// https://www.bmf.gv.at/dam/jcr:9f9f8d5f-5496-4886-aa4f-81a4e39ba83e/BMF_UID_Konstruktionsregeln.pdf
        /// </summary>
        internal static int CalcCheckSum(string numberPart)
        {
            var s3 = calcS(3);
            var s5 = calcS(5);
            var s7 = calcS(7);

            var r = s3 + s5 + s7;

            return (10 - ((r + c(2) + c(4) + c(6) + c(8) + 4) % 10)) % 10;

            int c(int position)
            {
                var index = position - 2;
                return int.Parse(numberPart[index].ToString());
            }

            int calcS(int position)
            {
                var ci = c(position);

                return ((ci / 5) + (ci * 2) % 10);
            }
        }
    }
}