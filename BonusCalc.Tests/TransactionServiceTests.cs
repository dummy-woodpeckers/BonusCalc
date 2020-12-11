using System;
using Xunit;

namespace BonusCalc.Tests
{
    /// <summary>
    /// actually structure of classes can be tested in the not such integration maner, but I'm to lazy now to implement separate class testing with mocks :)
    /// I think it is enough for unclear(see notes) test task 
    /// and shows not only my good side but bad too
    /// </summary>
    public class TransactionServiceTests
    {
        private readonly User User = new User(Currency.Usd);
        const decimal BonusPercent = 1m;
        const int OperationsPerDay = 10;
        const decimal TransactionThreshold = 5m;

        // usually it is done by DI and so ugly as here
        readonly TransactionService TransactionService = new TransactionService(
            CurrencyConverter.Instance,
            new IBonusCalculator[] {
                new FixedCurrencyUnit(TransactionThreshold, BonusPercent),
                new NumberOperationsPerDay(OperationsPerDay, BonusPercent) });

        public TransactionServiceTests()
        {
            User.Accounts.Add(new Account(Currency.Usd));
            User.Accounts.Add(new Account(Currency.Eur));
        }

        [Fact]
        public void NoBonusesForLowSpend()
        {
            TransactionService.Spend(User, new CurrencyAmount(Currency.Usd, 1), DateTime.Now);
            Assert.Empty(User.BonusAccount.Transactions);
        }

        [Fact]
        public void BonusesForTransactionThreshold()
        {
            const decimal amount = TransactionThreshold + 0.01m;
            var now = DateTime.Now;
            TransactionService.Spend(User, new CurrencyAmount(Currency.Usd, amount), now);

            Assert.Single(User.BonusAccount.Transactions);
            Assert.Equal(amount / 100 * BonusPercent, User.BonusAccount.Transactions[0].Amount);
        }

        [Fact]
        public void NoBonusesForTransactionNumberDifferentDays()
        {
            const decimal amount = 0.1m;
            var today = DateTime.Now;
            var tomorrow = today.AddDays(1);
            foreach (var date in new[] { today, tomorrow })
            {
                for (var t = 0; t < OperationsPerDay - 1; t++)
                    TransactionService.Spend(User, new CurrencyAmount(Currency.Usd, amount), date);
            }

            Assert.Empty(User.BonusAccount.Transactions);
        }

        [Fact]
        public void BonusesForTransactionNumberPerDay()
        {
            const decimal amount = 0.1m;
            var today = DateTime.Now;

            for (var t = 0; t < OperationsPerDay; t++)
                TransactionService.Spend(User, new CurrencyAmount(Currency.Usd, amount), today);

            Assert.Single(User.BonusAccount.Transactions);
            Assert.Equal(amount * OperationsPerDay / 100 * BonusPercent, User.BonusAccount.Transactions[0].Amount);
        }
    }
}
