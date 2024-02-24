using System;
using System.Runtime.Serialization;
using Services.Common.Model;

namespace Services.Transaction.Models
{
    [Serializable]
    public class InsufficientFundsException : ServiceException
    {
        public InsufficientFundsException()
        {
        }

        public InsufficientFundsException(string message) : base(message)
        {
        }

        public InsufficientFundsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InsufficientFundsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
