using System.Text.RegularExpressions;

namespace AmountToEnglishCurrency.Util
{
    public static class StringExtenstions
    {
        public static bool IsValidAmount(this string number)
        {
            var regex = @"^[0-9]*(\.[0-9]{1,2})?$";
            return Regex.IsMatch(number, regex);
        }
    }
}
