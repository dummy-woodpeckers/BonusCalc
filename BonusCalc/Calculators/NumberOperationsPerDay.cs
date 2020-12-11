using System;
using System.Collections.Generic;

namespace BonusCalc
{
    // - makes 10+ spend operations per day (additional 1% of total amount)
    // *** note: not clear assuming per account
    public class NumberOperationsPerDay : IBonusCalculator
    {
        private struct Count
        {
            public int Operations;
            public decimal Sum;
        }

        readonly Dictionary<(DateTime, Guid), Count> Counts = new Dictionary<(DateTime, Guid), Count>();
        private readonly decimal Hundredth;
        private readonly int Thershold;

        public NumberOperationsPerDay(int thershold, decimal bonusPercent)
        {
            Hundredth = bonusPercent / 100;
            Thershold = thershold;
        }

        public decimal Calculate(Transaction transaction, User user)
        {
            var key = (transaction.Timestamp.Date, transaction.Account.Id);
            Counts.TryGetValue(key, out var count);
            if (count.Operations == Thershold)
            {
                return 0m; // and stop wasting time
            }

            count.Operations++;
            count.Sum += transaction.Amount;

            Counts[key] = count;

            if (count.Operations == Thershold)
            {
                return count.Sum * Hundredth;
            }

            return 0;
        }
    }
}
