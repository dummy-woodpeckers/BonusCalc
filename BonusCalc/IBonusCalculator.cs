namespace BonusCalc
{
    public interface IBonusCalculator 
    {
        decimal Calculate(Transaction transaction, User user);
    }
}
