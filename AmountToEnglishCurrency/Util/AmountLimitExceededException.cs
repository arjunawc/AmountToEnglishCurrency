using System;

namespace AmountToEnglishCurrency.Util
{
    [Serializable]
    public class AmountLimitExceededException : Exception
    {
        public AmountLimitExceededException()
        {
        }

        public AmountLimitExceededException(string message)
            : base(message)
        {
        }

        public AmountLimitExceededException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
