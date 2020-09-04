using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace AmountToEnglishCurrency.Tests.TestData
{
    public class InvalidAmountData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "ABC" };
            yield return new object[] { "1.2.3" };
            yield return new object[] { "@58Y" };
            yield return new object[] { "@#$%" };
        }
    }
}
