namespace BonusCalc
{
    public static class CurrencyConverterExtensions
    {
        public static decimal Convert(this ICurrencyConverter converter, CurrencyAmount from, Currency to) => 
            converter.Convert(from.Currency, to, from.Amount);
    }
}

