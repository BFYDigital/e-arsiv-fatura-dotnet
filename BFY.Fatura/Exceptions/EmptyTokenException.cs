using System;
using System.Runtime.Serialization;

namespace BFY.Fatura.Exceptions
{
    class EmptyTokenException : Exception
    {
        public EmptyTokenException(string message) : base(message) { }

        public EmptyTokenException(string message, Exception innerException)
            : base(message, innerException) { }
        protected EmptyTokenException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
