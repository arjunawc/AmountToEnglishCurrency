using AmountToEnglishCurrency.Tests.TestData;
using AmountToEnglishCurrency.Util;
using Xunit;

namespace AmountToEnglishCurrency.Tests.Services
{
    public class CurrencyTranslateTest : IClassFixture<CurrencyTranslateTestFixture>
    {
        private readonly CurrencyTranslateTestFixture _currencyTranslateFixture;

        public CurrencyTranslateTest(CurrencyTranslateTestFixture currencyTranslateFixture)
        {
            _currencyTranslateFixture = currencyTranslateFixture;
        }

        [Theory]
        [CurrencyData]
        public void CurrencyToWords_ShouldReturn_CorrectWords(string currency, string expectedResult)
        {
            // Act
            var result = _currencyTranslateFixture.CurrencyTranslateService.CurrencyToWords(currency);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InvalidAmountData]
        public void Exception_When_CurrencyToWords_InvalidAmount(string invalidAmount)
        {
            Assert.Throws<InvalidAmountException>(() =>
                        _currencyTranslateFixture.CurrencyTranslateService.CurrencyToWords(invalidAmount));
        }
    }
}
