namespace BonusCalc
{
    public class FixedCurrencyUnit : IBonusCalculator
    {
        private readonly decimal Threshold;
        private readonly decimal Hundredth;

        public FixedCurrencyUnit(decimal threshold, decimal percent)
        {
            Threshold = threshold;
            Hundredth = percent / 100;
        }

        public decimal Calculate(Transaction transaction, User user)
        {
            if (transaction.Amount <= Threshold)
                return 0;

            // the user spends more than 5 currency units (5 USD, 5 EUR, etc.) from the account (1% bonus)
            // *** note: not clear from Amount or from sum that exceeds a threshold
            // *** not works for every transaction not just one per day or so

            return transaction.Amount * Hundredth;
        }
    }
}
