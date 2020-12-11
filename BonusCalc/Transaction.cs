using System;

namespace BonusCalc
{
    public readonly struct Transaction
    {
        public Guid Id { get; }

        public Account Account { get; }
        public decimal Amount { get; }
        public DateTime Timestamp { get; }

        public Transaction(Account account, decimal amount) : this(account, amount, DateTime.Now) { }

        public Transaction(Account account, decimal amount, DateTime timestamp)
        {
            Account = account;
            Amount = amount;
            Id = Guid.NewGuid();
            Timestamp = timestamp;
        }
    }
}
