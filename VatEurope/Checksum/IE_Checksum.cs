using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VatEurope.Checksum
{
    internal sealed class IE_Checksum : IChecksum
    {
        private const string _regexFullStringV1 = @"^IE[0-9][A-Z\+\*][0-9]{5}[A-W]$";
        private const string _regexFullStringV2 = @"^IE[0-9]{7}[A-W]$";
        private const string _regexFullStringV3 = @"^IE[0-9]{7}[A-W][A-I]$";

        private static IReadOnlyDictionary<int, char> _checkNumberDictionary = new ConcurrentDictionary<int, char>
        (
            new Dictionary<int, char>()
            {
                { 0, 'W' },
                { 1, 'A' },
                { 2, 'B' },
                { 3, 'C' },
                { 4, 'D' },
                { 5, 'E' },
                { 6, 'F' },
                { 7, 'G' },
                { 8, 'H' },
                { 9, 'I' },
                { 10, 'J' },
                { 11, 'K' },
                { 12, 'L' },
                { 13, 'M' },
                { 14, 'N' },
                { 15, 'O' },
                { 16, 'P' },
                { 17, 'Q' },
                { 18, 'R' },
                { 19, 'S' },
                { 20, 'T' },
                { 21, 'U' },
                { 22, 'V' },
            }
        );

        private static IReadOnlyDictionary<char, int> _letterToNumberDictionary = new ConcurrentDictionary<char, int>
        (
            new Dictionary<char, int>()
            {
                { 'A', 1 },
                { 'B', 2 },
                { 'C', 3 },
                { 'D', 4 },
                { 'E', 5 },
                { 'F', 6 },
                { 'G', 7 },
                { 'H', 8 },
                { 'I', 9 }
            }
        );

        public bool IsValidChecksum(string vat)
        {
            if (string.IsNullOrEmpty(vat))
            {
                return false;
            }

            if (Regex.IsMatch(vat, _regexFullStringV1))
            {
                return CalcCheckSumV1(vat.Substring(2, 8));
            }

            if (Regex.IsMatch(vat, _regexFullStringV2))
            {
                return CalcCheckSumV2(vat.Substring(2, 8));
            }

            if (Regex.IsMatch(vat, _regexFullStringV3))
            {
                return CalcCheckSumV3(vat.Substring(2, 9));
            }

            return false;
        }

        internal static bool CalcCheckSumV1(string numberPart)
        {
            var R = (c(3) * 7 + c(4) * 6 + c(5) * 5 + c(6) * 4 + c(7) * 3 + c(1) * 2) % 23;
            return numberPart[7].Equals(_checkNumberDictionary[R]);

            int c(int index)
            {
                return int.Parse(numberPart[index - 1].ToString());
            }
        }

        internal static bool CalcCheckSumV2(string numberPart)
        {
            var R = (c(1) * 8 + c(2) * 7 + c(3) * 6 + c(4) * 5 + c(5) * 4 + c(6) * 3 + c(7) * 2) % 23;
            return numberPart[7].Equals(_checkNumberDictionary[R]);

            int c(int index)
            {
                return int.Parse(numberPart[index - 1].ToString());
            }
        }

        internal static bool CalcCheckSumV3(string numberPart)
        {
            var R = (c(1) * 8 + c(2) * 7 + c(3) * 6 + c(4) * 5 + c(5) * 4
                + c(6) * 3 + c(7) * 2 + _letterToNumberDictionary[numberPart[8]] * 9) % 23;

            return numberPart[7].Equals(_checkNumberDictionary[R]);

            int c(int index)
            {
                return int.Parse(numberPart[index - 1].ToString());
            }
        }
    }
}