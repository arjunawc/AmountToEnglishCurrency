using System.Text.RegularExpressions;

namespace AmountToEnglishCurrency.Util
{
    public static class Helpers
    {
        public static string CurrencyFomatter(string strNumber, string word)
        {
            if (IsMoreThanOne(strNumber))
                return $" {word}s";

            return $" {word}";
        }

        public static bool IsZero(string strNumber)
        {
            var regex = @"(?<!\.)\b0(?:\.0+)?(?!\.)\b|^$";
            return Regex.IsMatch(strNumber, regex);
        }

        public static bool IsMoreThanOne(string strNumber)
        {
            var regex = @"^[2-9]|[1-9]\d+$";
            return Regex.IsMatch(strNumber, regex);
        }
    }
}
