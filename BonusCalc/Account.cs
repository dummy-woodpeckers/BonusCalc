using System;
using System.Collections.Generic;

namespace BonusCalc
{
    public class Account
    {
        public Guid Id { get; } = Guid.NewGuid();
        public Currency Currency { get; }
        public IList<Transaction> Transactions { get; } = new List<Transaction>();

        public Account(Currency currency)
        {
            Currency = currency;
        }
    }
}
