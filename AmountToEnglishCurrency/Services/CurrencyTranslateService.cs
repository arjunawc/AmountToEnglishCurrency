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
			var decimalPart = "";

			if (!input.IsValidAmount())
			{
				throw new InvalidAmountException("Invalid amount");
			}

			if (input.Contains("."))
			{
				decimalPart = input.Substring(input.IndexOf(".") + 1);
				if (decimalPart.Length == 1) { decimalPart = $"{decimalPart}0"; }
				input = input.Remove(input.IndexOf("."));
			}			

			if (Helpers.IsZero(input))
			{
				strWords.Append("Zero Dollars");
			}
            else
            {
				strWords.Append(WholeNumberToWords(input));
				strWords.Append(Helpers.CurrencyFomatter(input, "Dollar"));
			}

			strWords.Append(" and ");

			if (Helpers.IsZero(decimalPart))
			{
				strWords.Append("Zero Cents");
			}
			else
            {
				strWords.Append(WholeNumberToWords(decimalPart));
				strWords.Append(Helpers.CurrencyFomatter(decimalPart, "Cent"));
			}

			return strWords.ToString();
		}

		private string WholeNumberToWords(string number)
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

				if(i > _seperators.Length - 1) { throw new AmountLimitExceededException("Amount Limit Exceeded. Please Update the Seperators"); }
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
