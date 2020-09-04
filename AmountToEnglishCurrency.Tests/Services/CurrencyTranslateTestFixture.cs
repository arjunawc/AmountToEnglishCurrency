using AmountToEnglishCurrency.Interfaces;
using AmountToEnglishCurrency.Services;
using System;

namespace AmountToEnglishCurrency.Tests.Services
{
    public class CurrencyTranslateTestFixture : IDisposable
    {
        public ICurrencyTranslateService CurrencyTranslateService { get; private set; }

        public CurrencyTranslateTestFixture()
        {
            CurrencyTranslateService = new CurrencyTranslateService();
        }

        public void Dispose()
        {
            // Cleanup
        }
    }
}
