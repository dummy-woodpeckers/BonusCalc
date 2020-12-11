using System;
using System.Collections.Generic;

namespace BonusCalc
{
    public class TransactionService
    {
        private readonly ICurrencyConverter Converter;
        private readonly IEnumerable<IBonusCalculator> Calculators;

        public TransactionService(
            ICurrencyConverter converter,
            IEnumerable<IBonusCalculator> calculators)
        {
            Converter = converter;
            Calculators = calculators;
        }

        public void Spend(User user, CurrencyAmount currencyAmount, DateTime timestamp)
        {
            var account = user.GetAccount(currencyAmount.Currency);
            if (account == null)
                throw new FinanceException($"no account for {currencyAmount.Currency}");

            var transaction = new Transaction(account, currencyAmount.Amount, timestamp);
            account.Transactions.Add(transaction);

            foreach (var calc in Calculators)
            {
                var bonus = calc.Calculate(transaction, user);
                if (bonus > 0)
                {
                    MakeBonusTransaction(user, new CurrencyAmount(account.Currency, bonus));
                }
            }
        }

        private void MakeBonusTransaction(User user, CurrencyAmount bonusAmount)
        {
            var bonus = Converter.Convert(bonusAmount, user.BonusAccount.Currency);
            user.BonusAccount.Transactions.Add(new Transaction(user.BonusAccount, bonus));
        }
    }
}
