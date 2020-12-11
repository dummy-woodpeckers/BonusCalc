using System.Collections.Generic;
using System.Linq;

namespace BonusCalc
{
    public class User
    {
        public Account BonusAccount { get; }

        // assuming it can be more than one account with same currency
        public IList<Account> Accounts { get; } = new List<Account>();

        public Account GetAccount(Currency currency) =>
            Accounts.FirstOrDefault(s => s.Currency == currency);

        public User(Currency bonusAccountCurrency)
        {
            BonusAccount = new Account(bonusAccountCurrency);
        }
    }
}
