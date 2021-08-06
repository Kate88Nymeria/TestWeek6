using System;
using System.Runtime.Serialization;

namespace Banca
{
    public class RedCountException : Exception
    {
        public decimal Saldo { get; set; }
        public decimal ImportoOperazione { get; set; }

        public RedCountException()
        {
        }

        public RedCountException(string message) : base(message)
        {
        }

        public RedCountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RedCountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
