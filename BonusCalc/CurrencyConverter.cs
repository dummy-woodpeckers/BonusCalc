using System.Collections.Generic;

namespace BonusCalc
{
    public class CurrencyConverter : ICurrencyConverter
    {
        public static ICurrencyConverter Instance { get; } = new CurrencyConverter();

        static Dictionary<(Currency from, Currency to), decimal> Rates = new Dictionary<(Currency from, Currency to), decimal>
        {
            { (Currency.Usd, Currency.Eur), 1.2m},
            { (Currency.Eur, Currency.Usd), 1/1.2m},
        };

        protected CurrencyConverter() { }
        public decimal Convert(Currency from, Currency to, decimal amount) =>
            from != to ? amount * Rates[(from, to)] : amount;
    }
}

