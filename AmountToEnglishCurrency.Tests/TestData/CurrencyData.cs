using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace AmountToEnglishCurrency.Tests.TestData
{
    public class CurrencyData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "0", "Zero Dollars and Zero Cents" };
            yield return new object[] { "1.15", "One Dollar and Fifteen Cents" };
            yield return new object[] { "0.01", "Zero Dollars and One Cent" };
            yield return new object[] { "0.1", "Zero Dollars and Ten Cents" };
            yield return new object[] { "1", "One Dollar and Zero Cents" };
            yield return new object[] { "2", "Two Dollars and Zero Cents" };
            yield return new object[] { "1.50", "One Dollar and Fifty Cents" };
            yield return new object[] { "2.75", "Two Dollars and Seventy Five Cents" };
            yield return new object[] { "2147483648", "Two Billion One Hundred Forty Seven Million Four Hundred Eighty Three Thousand Six Hundred Forty Eight Dollars and Zero Cents" };
        }
    }
}