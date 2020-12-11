namespace BonusCalc
{
    public interface ICurrencyConverter
    {
        decimal Convert(Currency from, Currency to, decimal amount);
    }
}

