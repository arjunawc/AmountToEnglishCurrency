using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace AmountToEnglishCurrency.Tests.TestData
{
    public class MassiveAmountData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "999999999999999" };
            yield return new object[] { "1000000000000000000000" };
            yield return new object[] { "808808523262653247864652321249856" };
            yield return new object[] { "2589523252652629525941589484656468748896789748976456544124" };
        }
    }
}
