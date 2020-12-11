using System;

namespace BonusCalc
{
    public class FinanceException : Exception
    {
        public FinanceException(string message, Exception innerException = null) : base(message, innerException) { }
    }
}
