using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class BE_Checksum : IChecksum
    {
        private const string _regexFullString = @"^BE0[1-9][0-9]{8}$";

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

            var checksum = int.Parse(vat.Substring(10, 2));

            return checksum == CalcCheckSum(vat.Substring(2, 8));
        }

        /// <summary>
        /// https://www.bmf.gv.at/dam/jcr:9f9f8d5f-5496-4886-aa4f-81a4e39ba83e/BMF_UID_Konstruktionsregeln.pdf
        /// </summary>
        internal static int CalcCheckSum(string numberPart)
        {
            return 97 - (int.Parse(numberPart) % 97);
        }
    }
}