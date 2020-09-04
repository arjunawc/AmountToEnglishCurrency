namespace AmountToEnglishCurrency.Util
{
    public static class Helpers
    {
        public static string CurrencyFomatter(int count, string word)
        {
            if (count == 1)
            {
                return $" {word}";
            }
            else
            {
                return $" {word}s";
            }
        }
    }
}
