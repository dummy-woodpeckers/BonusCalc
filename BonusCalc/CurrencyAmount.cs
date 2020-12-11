namespace BonusCalc
{
    public readonly struct CurrencyAmount
    {
        public Currency Currency { get; }
        public decimal Amount { get; }

        public CurrencyAmount(Currency currency, decimal amount)
        {
            Currency = currency;
            Amount = amount;
        }
    }
}
