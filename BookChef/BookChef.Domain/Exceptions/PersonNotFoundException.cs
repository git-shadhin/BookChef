using System;
using System.Runtime.Serialization;

namespace BookChef.Domain.Exceptions
{
    public class PersonNotFoundException : Exception
    {
        public PersonNotFoundException()
        {
        }

        public PersonNotFoundException(string message)
            : base(message)
        {
        }

        public PersonNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected PersonNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}