using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace AmountToEnglishCurrency.Tests.TestData
{
    public class CurrencyData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "1.15", "One Dollar and Fifteen Cents" };
            yield return new object[] { "0.01", "One Cent" };
            yield return new object[] { "0.1", "Ten Cents" };
            yield return new object[] { "1", "One Dollar" };
            yield return new object[] { "2", "Two Dollars" };
            yield return new object[] { "1.50", "One Dollar and Fifty Cents" };
            yield return new object[] { "2.75", "Two Dollars and Seventy Five Cents" };
            yield return new object[] { "2147483647", "Two Billion One Hundred Forty Seven Million Four Hundred Eighty Three Thousand Six Hundred Forty Seven Dollars" };
        }
    }
}