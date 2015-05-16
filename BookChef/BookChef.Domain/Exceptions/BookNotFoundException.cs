using System;
using System.Runtime.Serialization;

namespace BookChef.Domain.Exceptions
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException()
        {
        }

        public BookNotFoundException(string message)
            : base(message)
        {
        }

        public BookNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected BookNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}