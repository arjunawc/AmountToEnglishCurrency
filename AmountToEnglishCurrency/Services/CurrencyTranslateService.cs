using AmountToEnglishCurrency.Interfaces;
using AmountToEnglishCurrency.Util;
using System.Text;

namespace AmountToEnglishCurrency.Services
{
    public class CurrencyTranslateService : ICurrencyTranslateService
	{
        private readonly string[] _seperators = { "", " Thousand ", " Million ", " Billion " };
		private readonly string[] _ones =
		{
			"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
			"Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
		};
		private readonly string[] _tens = { "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

		
		public string CurrencyToWords(string input)
		{
			StringBuilder strWords = new StringBuilder();
            int inputValue, decimalPartValue = 0;

			if (!input.IsValidAmount())
			{
				throw new InvalidAmountException("Invalid amount");
			}

			if (input.Contains("."))
			{
                var decimalPart = input.Substring(input.IndexOf(".") + 1);
                if (decimalPart.Length == 1) { decimalPart = $"{decimalPart}0"; }
				input = input.Remove(input.IndexOf("."));
				decimalPartValue = int.Parse(decimalPart);
			}

			inputValue = int.Parse(input);

			strWords.Append(WholeNumberToWords(inputValue));

			if (inputValue > 0)
			{
				strWords.Append(Helpers.CurrencyFomatter(inputValue, "Dollar"));
			}

			if (decimalPartValue > 0)
			{
				if (inputValue > 0) { strWords.Append(" and "); }

				strWords.Append(WholeNumberToWords(decimalPartValue));
				strWords.Append(Helpers.CurrencyFomatter(decimalPartValue, "Cent"));
			}

			return strWords.ToString();
		}

		private string WholeNumberToWords(int number)
		{
			int i = 0;
			string strNumber = number.ToString();
			string strWords = "";			

			while (strNumber.Length > 0)
			{
				string strThreeDigits = strNumber.Length < 3 ? strNumber : strNumber.Substring(strNumber.Length - 3);
				strNumber = strNumber.Length < 3 ? "" : strNumber.Remove(strNumber.Length - 3);
				int threeDigitsValue = int.Parse(strThreeDigits);

				strThreeDigits = ThreeDigitsToWord(threeDigitsValue);

				strThreeDigits += _seperators[i];

				strWords = strThreeDigits + strWords;

				i++;
			}
			return strWords;
		}

		private string ThreeDigitsToWord(int number)
		{
			StringBuilder word = new StringBuilder();

			if (number > 99 && number < 1000)
			{
				int i = number / 100;
				word.Append($"{ _ones[i - 1]} Hundred ");
				number %= 100;
			}

			if (number > 19 && number < 100)
			{
				int i = number / 10;
				word.Append($"{_tens[i - 1]} ");
				number %= 10;
			}

			if (number > 0 && number < 20)
			{
				word.Append(_ones[number - 1]);
			}

			return word.ToString().Trim();
		}
	}
}
