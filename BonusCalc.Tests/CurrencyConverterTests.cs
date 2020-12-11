using Xunit;

namespace BonusCalc.Tests
{
    public class CurrencyConverterTests
    {
        readonly ICurrencyConverter Unit;

        public CurrencyConverterTests() =>
            Unit = CurrencyConverter.Instance;

        [Fact]
        public void UsdEur() =>
            Assert.Equal(1 / 1.2m, Unit.Convert(Currency.Eur, Currency.Usd, 1m));

        [Fact]
        public void EurUsd() =>
            Assert.Equal(1.2m, Unit.Convert(Currency.Usd, Currency.Eur, 1m));
    }
}
